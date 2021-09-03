using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfReactorUI.Animations;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public interface IVisualNode
    {
        void AppendAnimatable<T>(object key, T animation, Action<T> action) where T : RxAnimation;


        //Action<object, PropertyChangingEventArgs> PropertyChangingAction { get; set; }
        //Action<object, PropertyChangedEventArgs> PropertyChangedAction { get; set; }

    }

    public static class VisualNodeExtensions
    {
        //public static T OnPropertyChanged<T>(this T element, Action<object, PropertyChangedEventArgs> action) where T : VisualNode
        //{
        //    element.PropertyChangedAction = action;
        //    return element;
        //}

        //public static T OnPropertyChanging<T>(this T element, Action<object, System.ComponentModel.PropertyChangingEventArgs> action) where T : VisualNode
        //{
        //    element.PropertyChangingAction = action;
        //    return element;
        //}

        public static T? If<T>(this T node, bool flag) where T : VisualNode
        {
            if (flag)
            {
                return node;
            }

            return null;
        }

        public static T When<T>(this T node, bool flag, Action<T> actionToApplyWhenFlagIsTrue) where T : VisualNode
        {
            if (flag)
            {
                actionToApplyWhenFlagIsTrue(node);
            }
            return node;
        }

        public static T WithAnimation<T>(this T node, Easing? easing = null, double duration = 600) where T : VisualNode
        {
            node.EnableCurrentAnimatableProperties(easing, duration);
            return node;
        }

        public static T WithKey<T>(this T node, object key) where T : VisualNode
        {
            node.Key = key;
            return node;
        }

        public static T WithMetadata<T>(this T node, string key, object value) where T : VisualNode
        {
            node.SetMetadata(key, value);
            return node;
        }

        public static T WithMetadata<T>(this T node, object value) where T : VisualNode
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            node.SetMetadata(value.GetType().FullName ?? throw new InvalidOperationException(), value);
            return node;
        }

        public static T WithOutAnimation<T>(this T node) where T : VisualNode
        {
            node.DisableCurrentAnimatableProperties();
            return node;
        }
    }

    public abstract class VisualNode : IVisualNode
    {
        private bool _isMounted = false;

        private bool _stateChanged = true;

        private readonly Dictionary<object, Animatable> _animatables = new Dictionary<object, Animatable>();

        private readonly Dictionary<string, object?> _metadata = new Dictionary<string, object?>();



        private IReadOnlyList<VisualNode>? _children = null;

        private bool _invalidated = false;

        protected VisualNode()
        {
            //System.Diagnostics.Debug.WriteLine($"{this}->Created()");
        }

        public int ChildIndex { get; private set; }
        public object? Key { get; set; }
        //public Action<object, PropertyChangedEventArgs> PropertyChangedAction { get; set; }
        //public Action<object, System.ComponentModel.PropertyChangingEventArgs> PropertyChangingAction { get; set; }

        //internal event EventHandler LayoutCycleRequest;
        internal IReadOnlyList<VisualNode> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<VisualNode>(RenderChildren().Where(_ => _ != null));
                    for (int i = 0; i < _children.Count; i++)
                    {
                        _children[i].ChildIndex = i;
                        _children[i].Parent = this;
                    }
                }
                return _children;
            }
        }

        internal void InvalidateChildren()
            => _children = null;

        internal bool IsAnimationFrameRequested { get; private set; } = false;
        internal bool IsLayoutCycleRequired { get; set; } = true;
        internal VisualNode? Parent { get; private set; }

        protected bool IsMounted
        {
            get => _isMounted;
            set
            {
                _isMounted = value;
            }
        }

        public virtual INavigation? Navigation
            => Parent?.Navigation;

        public void AppendAnimatable<T>(object key, T animation, Action<T> action) where T : RxAnimation
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (animation is null)
            {
                throw new ArgumentNullException(nameof(animation));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var newAnimatableProperty = new Animatable(key, animation, new Action<RxAnimation>(target => action((T)target)));

            _animatables[key] = newAnimatableProperty;
        }

        public T? GetMetadata<T>(string key, T? defaultValue = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("can'be null or empty", nameof(key));
            }

            if (_metadata.TryGetValue(key, out var value))
                return (T?)value;

            return defaultValue;
        }

        public T? GetMetadata<T>(T? defaultValue = default)
            => GetMetadata(typeof(T).FullName ?? throw new InvalidOperationException("typeof(T).FullName returns null"), defaultValue);

        public void SetMetadata<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("can'be null or empty", nameof(key));
            }

            _metadata[key] = value;
        }

        public void SetMetadata<T>(T value)
        {
            _metadata[typeof(T).FullName ?? throw new InvalidOperationException("typeof(T).FullName returns null")] = value;
        }

        internal void AddChild(VisualNode widget, object childNativeControl)
        {
            OnAddChild(widget, childNativeControl);
        }

        internal virtual bool Animate()
        {
            if (!IsAnimationFrameRequested)
                return false;

            var animated = AnimateThis();

            OnAnimate();

            foreach (var child in Children)
            {
                if (child.Animate())
                    animated = true;
            }

            if (!animated)
            {
                IsAnimationFrameRequested = false;
            }

            return animated;
        }

        internal void DisableCurrentAnimatableProperties()
        {
            foreach (var _ in _animatables.Where(_ => _.Value.IsEnabled == null))
            {
                _.Value.IsEnabled = false;
            };
        }

        internal void EnableCurrentAnimatableProperties(Easing? easing = null, double duration = 600)
        {
            foreach (var _ in _animatables.Where(_ => _.Value.IsEnabled == null).Select(_ => _.Value))
            {
                if (_.Animation is RxTweenAnimation tweenAnimation)
                {
                    tweenAnimation.Easing ??= easing;
                    tweenAnimation.Duration ??= duration;
                    _.IsEnabled = true;
                }
            };
        }

        internal virtual void Layout(IRxComponentWithState? containerComponent = null)
        {
            if (!IsLayoutCycleRequired)
                return;

            IsLayoutCycleRequired = false;

            if (_invalidated)
            {
                var oldChildren = Children;
                _children = null;
                MergeChildrenFrom(oldChildren);
                _invalidated = false;
            }

            if (!_isMounted && Parent != null)
                OnMount();

            CommitAnimations();

            AnimateThis();

            if (_stateChanged)
                OnUpdate();

            foreach (var child in Children)
                child.Layout();
        }

        internal virtual void MergeChildrenFrom(IReadOnlyList<VisualNode> oldChildren)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (oldChildren.Count > i)
                {
                    oldChildren[i].MergeWith(Children[i]);
                }
            }

            for (int i = Children.Count; i < oldChildren.Count; i++)
            {
                oldChildren[i].Unmount();
                //oldChildren[i].Parent = null;
            }
        }

        internal virtual void MergeWith(VisualNode newNode)
        {
            if (newNode == this)
                return;

            for (int i = 0; i < Children.Count; i++)
            {
                if (newNode.Children.Count > i)
                {
                    Children[i].MergeWith(newNode.Children[i]);
                }
            }

            for (int i = newNode.Children.Count; i < Children.Count; i++)
            {
                Children[i].Unmount();
            }
        }

        internal void RemoveChild(VisualNode widget, object childNativeControl)
        {
            OnRemoveChild(widget, childNativeControl);
        }

        internal void Unmount()
        {
            OnUnmount();
        }

        protected internal virtual void OnLayoutCycleRequested()
        {
        }

        protected virtual void CommitAnimations()
        {
            if (_animatables.Any(_ => _.Value.IsEnabled.GetValueOrDefault() && !_.Value.Animation.IsCompleted()))
            {
                RequestAnimationFrame();
            }
        }

        protected T? GetParent<T>() where T : VisualNode
        {
            var parent = Parent;
            while (parent != null && !(parent is T))
                parent = parent.Parent;

            return (T?)parent;
        }

        protected void Invalidate()
        {
            _invalidated = true;

            RequireLayoutCycle();

            OnInvalidated();
            //System.Diagnostics.Debug.WriteLine($"{this}->Invalidated()");
        }

        protected virtual void OnAddChild(VisualNode widget, object childNativeControl)
        {
        }

        protected virtual void OnAnimate()
        {
        }

        protected virtual void OnInvalidated()
        {
        }

        protected virtual void OnMigrated(VisualNode newNode)
        {
            foreach (var newAnimatableProperty in newNode._animatables)
            {
                if (_animatables.TryGetValue(newAnimatableProperty.Key, out var oldAnimatableProperty))
                {
                    if (oldAnimatableProperty.Animation.GetType() == newAnimatableProperty.Value.Animation.GetType())
                    {
                        newAnimatableProperty.Value.Animation.MigrateFrom(oldAnimatableProperty.Animation);
                    }
                }
            }

            _animatables.Clear();
        }

        protected virtual void OnMount()
        {
            _isMounted = true;
            //System.Diagnostics.Debug.WriteLine($"{this} Mounted");
        }

        protected virtual void OnRemoveChild(VisualNode widget, object childNativeControl)
        {
        }

        protected virtual void OnUnmount()
        {
            foreach (var child in Children)
            {
                child.Unmount();
            }

            _isMounted = false;
            Parent = null;
            //System.Diagnostics.Debug.WriteLine($"{this} Unmounted");
        }

        protected virtual void OnUpdate()
        {
            _stateChanged = false;
        }

        protected virtual IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }

        private bool AnimateThis()
        {
            bool animated = false;
            foreach (var _ in _animatables
                .Where(_ => _.Value.IsEnabled.GetValueOrDefault() && !_.Value.Animation.IsCompleted()))
            {
                _.Value.Animate();
                animated = true;
            };

            return animated;
        }

        private void RequestAnimationFrame()
        {
            IsAnimationFrameRequested = true;
            Parent?.RequestAnimationFrame();
        }

        private void RequireLayoutCycle()
        {
            if (IsLayoutCycleRequired)
                return;

            IsLayoutCycleRequired = true;
            Parent?.RequireLayoutCycle();
            OnLayoutCycleRequested();
        }
    }

    public abstract class VisualNodeWithAttachedProperties : VisualNode
    {
        public abstract void SetAttachedProperty(DependencyProperty property, object value);

        public abstract void OnEvent(RoutedEvent @event, RoutedEventHandler routedEventHandler);
    }

    public static class VisualNodeWithAttachedPropertiesExtensions
    {
        public static T Set<T>(this T element, DependencyProperty property, object value) where T : VisualNodeWithAttachedProperties
        {
            element.SetAttachedProperty(property, value);
            return element;
        }

        public static T On<T>(this T element, RoutedEvent @event, RoutedEventHandler routedEventHandler) where T : VisualNodeWithAttachedProperties
        {
            element.OnEvent(@event, routedEventHandler);
            return element;
        }
    }

    internal interface IVisualNodeWithNativeControl
    {
        TResult GetNativeControl<TResult>() where TResult : DependencyObject;

        bool TryGetDefaultPropertyValue(DependencyProperty dependencyProperty, out object? value);

        bool SetDefaultPropertyValue(DependencyProperty dependencyProperty, object value);
    }

    // public interface IVisualNodeWithAttachedProperties
    // {
    //     void SetAttachedProperty(DependencyProperty property, object value);
    // }

    public abstract class VisualNode<T> : VisualNodeWithAttachedProperties, IVisualNodeWithNativeControl where T : DependencyObject, new()
    {
        protected T? _nativeControl;

        private IRxComponentWithState? _containerComponent;

        private Dictionary<DependencyProperty, object> _defaultPropertyValueBag = new();

        private readonly Dictionary<DependencyProperty, object> _attachedProperties = new();

        private readonly Dictionary<RoutedEvent, RoutedEventHandler> _routedEvents = new();

        internal override void Layout(IRxComponentWithState? containerComponent = null)
        {
            _containerComponent = containerComponent;
            base.Layout(containerComponent);
        }

        public bool SetDefaultPropertyValue(DependencyProperty dependencyProperty, object value)
        {
            if (!_defaultPropertyValueBag.ContainsKey(dependencyProperty))
            {
                _defaultPropertyValueBag[dependencyProperty] = value;
                return true;
            }

            return false;
        }

        public bool TryGetDefaultPropertyValue(DependencyProperty dependencyProperty, out object? value)
        {
            if (_defaultPropertyValueBag.TryGetValue(dependencyProperty, out value))
            {
                _defaultPropertyValueBag.Remove(dependencyProperty);
                return true;
            }

            return false;
        }

        private readonly Action<T?>? _componentRefAction;

        protected VisualNode()
        { }

        protected VisualNode(Action<T?> componentRefAction)
        {
            _componentRefAction = componentRefAction;
        }

        protected T NativeControl 
        {
            get
            {
                if (_nativeControl == null)
                {
                    throw new InvalidOperationException();
                }

                return (T)_nativeControl;
            }
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode.GetType() == GetType())
            {
                ((VisualNode<T>)newNode).OnMergedWith(this);

                OnMigrated(newNode);

                base.MergeWith(newNode);
            }
            else
            {
                Unmount();
            }
        }

        internal virtual void OnMergedWith(VisualNode oldNode)
        {
            _nativeControl = ((VisualNode<T>)oldNode)._nativeControl;
            IsMounted = _nativeControl != null;
            _componentRefAction?.Invoke(_nativeControl);
            _defaultPropertyValueBag = ((VisualNode<T>)oldNode)._defaultPropertyValueBag;
        }

        protected override void OnMigrated(VisualNode newNode)
        {
            if (_nativeControl != null)
            {
                foreach (var attachedProperty in _attachedProperties)
                {
                    NativeControl.ClearValue(attachedProperty.Key);
                }

                if (NativeControl is UIElement childAsUiElement)
                {
                    foreach (var @eventHandler in _routedEvents)
                    {
                        childAsUiElement.RemoveHandler(eventHandler.Key, eventHandler.Value);
                    }
                }

                _attachedProperties.Clear();
                _routedEvents.Clear();

                OnDetachNativeEvents();
            }

            base.OnMigrated(newNode);
        }

        protected virtual void OnAttachNativeEvents()
        {

        }

        protected virtual void OnDetachNativeEvents()
        {

        }

        protected override void OnMount()
        {
            if (_nativeControl == null)
            {
                _nativeControl = new T();
                Parent?.AddChild(this, _nativeControl);
            }

            _componentRefAction?.Invoke(NativeControl);

            base.OnMount();
        }

        protected override void OnUnmount()
        {
            var parent = Parent;

            base.OnUnmount();

            if (_nativeControl != null)
            {
                OnDetachNativeEvents();

                parent?.RemoveChild(this, _nativeControl);

                _nativeControl = null;
            }
                
            _componentRefAction?.Invoke(null);
        }

        protected override void OnUpdate()
        {
            foreach (var attachedProperty in _attachedProperties)
            {
                NativeControl.SetValue(attachedProperty.Key, attachedProperty.Value);
            }

            if (NativeControl is UIElement childAsUiElement)
            {
                foreach (var @eventHandler in _routedEvents)
                {
                    childAsUiElement.AddHandler(eventHandler.Key, eventHandler.Value);
                }
            }

            OnAttachNativeEvents();

            base.OnUpdate();
        }

        TResult IVisualNodeWithNativeControl.GetNativeControl<TResult>()
        {
            return (_nativeControl as TResult) ??
                throw new InvalidOperationException($"Unable to convert from type {typeof(T)} to type {typeof(TResult)} when getting the native control");
        }

        public override void SetAttachedProperty(DependencyProperty property, object value)
            => _attachedProperties[property] = value;

        protected void SetPropertyValue(DependencyObject dependencyObject, DependencyProperty property, IPropertyValue? propertyValue)
        {
            if (propertyValue != null)
            {
                SetDefaultPropertyValue(property, dependencyObject.GetValue(property));
                dependencyObject.SetValue(property, propertyValue.GetValue());
                if (_containerComponent != null && propertyValue.HasValueFunction)
                {
                    _containerComponent.RegisterOnStateChanged(propertyValue.GetValueAction(dependencyObject, property));
                }
            }
            else
            {
                if (TryGetDefaultPropertyValue(property, out var defaultValue))
                {
                    dependencyObject.SetValue(property, defaultValue);
                }
            }
        }

        public override void OnEvent(RoutedEvent @event, RoutedEventHandler routedEventHandler)
            => _routedEvents[@event] = routedEventHandler;
        
    }

}
