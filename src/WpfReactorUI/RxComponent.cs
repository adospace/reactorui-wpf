using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public interface IRxComponent
    {
        RxContext Context { get; }
    }

    public abstract class RxComponent : VisualNodeWithAttachedProperties, IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _children = new();
        private readonly Dictionary<DependencyProperty, object> _attachedProperties = new();

        public abstract VisualNode Render();

        public override void SetAttachedProperty(DependencyProperty property, object value)
            => _attachedProperties[property] = value;

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }   

        public void Add(params VisualNode[] nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            _children.AddRange(nodes);
        }

        protected new IReadOnlyList<VisualNode> Children()
            => _children;

        private IRxHostElement? GetPageHost()
        {
            var current = Parent;
            while (current != null && !(current is IRxHostElement))
                current = current.Parent;

            return current as IRxHostElement;
        }

        private new bool IsMounted
        {
            set => base.IsMounted = value;
        }

        protected Window? ContainerWindow
        {
            get
            {
                return GetPageHost()?.ContainerWindow;
            }
        }

        protected sealed override void OnAddChild(VisualNode widget, object nativeControl)
        {
            if (Parent == null)
            {
                throw new InvalidOperationException($"Unable to add native control {nativeControl.GetType().FullName} (widget: {widget.GetType().FullName}): Parent is null");
            }

            if (nativeControl is DependencyObject childAsDependencyObject)
            {
                foreach (var attachedProperty in _attachedProperties)
                {
                    childAsDependencyObject.SetValue(attachedProperty.Key, attachedProperty.Value);
                }
            }

            Parent.AddChild(this, nativeControl);
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object nativeControl)
        {
            if (Parent == null)
            {
                throw new InvalidOperationException($"Unable to remove native control {nativeControl.GetType().FullName} (widget: {widget.GetType().FullName}): Parent is null");
            }

            Parent.RemoveChild(this, nativeControl);

            if (nativeControl is DependencyObject childAsDependencyObject)
            {
                foreach (var attachedProperty in _attachedProperties)
                {
                    childAsDependencyObject.ClearValue(attachedProperty.Key);
                }
            }
        }

        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Render();
        }

        protected sealed override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected sealed override void OnAnimate()
        {
            base.OnAnimate();
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode.GetType().FullName == GetType().FullName)
            {
                ((RxComponent)newNode).IsMounted = true;
                ((RxComponent)newNode).OnUpdated();
                base.MergeWith(newNode);
            }
            else
            {
                Unmount();
            }
        }

        protected sealed override void OnMount()
        {
            //System.Diagnostics.Debug.WriteLine($"Mounting {Key ?? GetType()} under {Parent.Key ?? Parent.GetType()} at index {ChildIndex}");

            base.OnMount();

            OnMounted();
        }

        protected virtual void OnMounted()
        {
        }

        protected sealed override void OnUnmount()
        {
            OnWillUnmount();

            //foreach (var child in base.Children)
            //{
            //    child.Unmount();
            //}

            base.OnUnmount();
        }

        protected virtual void OnWillUnmount()
        {
        }

        protected virtual void OnUpdated()
        { }

        public sealed override INavigation? Navigation => 
            base.Navigation;

        public static RxContext Context
            => RxApplication.Instance?.Context ?? throw new InvalidOperationException("Unable to get context without an active application");

    }

    public static class RxComponentExtensions
    {
        public static T WithContext<T>(this T node, string key, object value) where T : IRxComponent
        {
            node.Context[key] = value;
            return node;
        }
    }

    internal interface IRxComponentWithState
    {
        object State { get; }

        PropertyInfo[] StateProperties { get; }

        void ForwardState(object stateFromOldComponent, bool invalidateComponent);

        IRxComponentWithState? NewComponent { get; }

        void RegisterOnStateChanged(Action action);
    }

    internal interface IRxComponentWithProps
    {
        object Props { get; }

        PropertyInfo[] PropsProperties { get; }
    }

    public interface IState
    {
    }

    public interface IProps
    {
    }

    public abstract class RxComponentWithProps<P> : RxComponent, IRxComponentWithProps where P : class, IProps, new()
    {
        public RxComponentWithProps(P? props = null)
        {
            Props = props ?? new P();
        }

        public P Props { get; private set; }
        object IRxComponentWithProps.Props => Props;
        public PropertyInfo[] PropsProperties => typeof(P).GetProperties().Where(_ => _.CanWrite).ToArray();
    }

    public abstract class RxComponent<S, P> : RxComponentWithProps<P>, IRxComponentWithState where S : class, IState, new() where P : class, IProps, new()
    {
        private IRxComponentWithState? _newComponent;
        private readonly List<Action> _actionsRegisterdOnStateChange = new();

        protected RxComponent(S? state = null, P? props = null)
            : base(props)
        {
            State = state ?? new S();
        }

        public S State { get; private set; }

        public PropertyInfo[] StateProperties => typeof(S).GetProperties().Where(_ => _.CanWrite).ToArray();

        object IRxComponentWithState.State => State;

        IRxComponentWithState? IRxComponentWithState.NewComponent => _newComponent;

        private bool TryForwardStateToNewComponent(bool invalidateComponent)
        {
            var newComponent = _newComponent;
            while (newComponent != null && newComponent.NewComponent != null)
                newComponent = newComponent.NewComponent;

            if (newComponent != null)
            {
                newComponent.ForwardState(State, invalidateComponent);
                return true;
            }

            return false;
        }

        protected virtual void SetState(Action<S> action, bool invalidateComponent = false)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            action(State);

            if (TryForwardStateToNewComponent(invalidateComponent))
                return;

            _actionsRegisterdOnStateChange.ForEach(_ => _());

            if (!Dispatcher.CurrentDispatcher.CheckAccess())
                Dispatcher.CurrentDispatcher.BeginInvoke(Invalidate);
            else
                Invalidate();
        }

        void IRxComponentWithState.RegisterOnStateChanged(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _actionsRegisterdOnStateChange.Add(action);
        }

        void IRxComponentWithState.ForwardState(object stateFromOldComponent, bool invalidateComponent)
        {
            stateFromOldComponent.CopyPropertiesTo(State, StateProperties);

            _actionsRegisterdOnStateChange.ForEach(_ => _());

            if (invalidateComponent)
            {
                if (!Dispatcher.CurrentDispatcher.CheckAccess())
                    Dispatcher.CurrentDispatcher.BeginInvoke(Invalidate);
                else
                    Invalidate();
            }
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode != this && newNode.GetType().FullName == GetType().FullName)
            {
                if (newNode is IRxComponentWithState newComponentWithState)
                {
                    _newComponent = newComponentWithState;

                    State.CopyPropertiesTo(newComponentWithState.State, newComponentWithState.StateProperties);
                }

                if (newNode is IRxComponentWithProps newComponentWithProps)
                {
                    Props.CopyPropertiesTo(newComponentWithProps.Props, newComponentWithProps.PropsProperties);
                }
            }

            base.MergeWith(newNode);
        }
    }

    public class EmptyProps : IProps
    { }

    public abstract class RxComponent<S> : RxComponent<S, EmptyProps> where S : class, IState, new()
    {
        protected RxComponent(S? state = null, EmptyProps? props = null)
            : base(state, props)
        {
        }
    }

}
