using WpfReactorUI.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace WpfReactorUI
{
    public abstract class RxApplication : VisualNode, IRxHostElement
    {
        public static RxApplication Instance { get; private set; }
        protected readonly Application _application;

        //internal IComponentLoader ComponentLoader { get; set; } = new LocalComponentLoader();

        protected RxApplication(Application application)
        {
            //if (Instance != null)
            //{
            //    throw new InvalidOperationException("Only one instance of RxApplication is permitted");
            //}

            Instance = this;

            _application = application ?? throw new ArgumentNullException(nameof(application));

        }

        public Action<UnhandledExceptionEventArgs> UnhandledException { get; set; }

        internal void FireUnhandledExpectionEvent(Exception ex)
        {
            UnhandledException?.Invoke(new UnhandledExceptionEventArgs(ex, false));
            System.Diagnostics.Debug.WriteLine(ex);
        }

        public abstract IRxHostElement Run();

        public abstract void Stop();

        public static RxApplication Create<T>(Application application) where T : RxComponent, new()
            => new RxApplication<T>(application);

        // public static RxApplication CreateWithHotReload<T>(Application application) where T : RxComponent, new()
        //     => new RxHotReloadApplication<T>(application);

        public RxApplication WithContext(string key, object value)
        {
            Context[key] = value;
            return this;
        }

        public RxApplication OnUnhandledException(Action<UnhandledExceptionEventArgs> action)
        {
            UnhandledException = action;
            return this;
        }

        //public INavigation Navigation => _application.MainWindow?.Navigation;

        public RxContext Context { get; } = new RxContext();

        public Window ContainerWindow
        {
            get
            {
                return _application.MainWindow;
            }
        }

    }

    public class RxApplication<T> : RxApplication where T : RxComponent, new()
    {
        protected RxComponent _rootComponent;
        private bool _sleeping = true;
        private readonly DispatcherTimer _animationTimer = null;


        internal RxApplication(Application application)
            : base(application)
        {
            _animationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };
            _animationTimer.Tick += (s, e) =>
            {
                Animate();
                if (!IsAnimationFrameRequested)
                {
                    _animationTimer.Stop();
                }
            };
        }

        protected sealed override void OnAddChild(VisualNode widget, object nativeControl)
        {
            if (nativeControl is Window window)
            {
                _application.MainWindow = window;
                _application.MainWindow.Show();
            }
            else
            {
                throw new NotSupportedException($"Invalid root component ({nativeControl.GetType()}): must be a window (i.e. RxWindow)");
            }
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object nativeControl)
        {
            _application.MainWindow?.Close();
        }

        public override IRxHostElement Run()
        {
            if (_sleeping)
            {
                _rootComponent ??= new T();
                _sleeping = false;
                
                OnLayout();

            }

            if (ComponentLoader.Instance != null)
            {
                ComponentLoader.Instance.ComponentAssemblyChanged += OnComponentAssemblyChanged;
                ComponentLoader.Instance.Run();
            }

            return this;
        }

        private void OnComponentAssemblyChanged(object sender, EventArgs e)
        {
            if (!_application.Dispatcher.CheckAccess())
            {
                _application.Dispatcher.BeginInvoke(() => OnComponentAssemblyChanged(sender, e));
                return;
            }

            try
            {
                var newComponent = ComponentLoader.Instance.LoadComponent<T>();

                if (newComponent != null)
                {
                    _rootComponent = newComponent;
                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                FireUnhandledExpectionEvent(ex);
            }
        }

        public override void Stop()
        {
            if (!_sleeping)
            {
                _sleeping = true;
            }

            if (ComponentLoader.Instance != null)
            {
                ComponentLoader.Instance.ComponentAssemblyChanged -= OnComponentAssemblyChanged;
                ComponentLoader.Instance.Stop();
            }
        }

        protected internal override void OnLayoutCycleRequested()
        {
            if (!_sleeping)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(OnLayout);
            }

            base.OnLayoutCycleRequested();
        }

        private void OnLayout()
        {
            try
            {
                Layout();

                _animationTimer.IsEnabled = IsAnimationFrameRequested;
            }
            catch (Exception ex)
            {
                FireUnhandledExpectionEvent(ex);
            }
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield return _rootComponent;
        }


    }

    // public class RxHotReloadApplication<T> : RxApplication<T> where T : RxComponent, new()
    // {
    //     private readonly HotReloadServer _hotReloadServer;


    //     internal RxHotReloadApplication(Application application, int serverPort = 45821) : base(application)
    //     {
    //         _hotReloadServer = new HotReloadServer(serverPort);
    //     }

    //     public override IRxHostElement Run()
    //     {
    //         _hotReloadServer.HotReloadCommandIssued += OnHotReloadServer_HotReloadCommandIssued;
    //         _hotReloadServer.Start();

    //         return base.Run();
    //     }

    //     private void OnHotReloadServer_HotReloadCommandIssued(object sender, AssemblyToReloadEventArgs e)
    //     {
    //         try
    //         {
    //             var assemblyPath = e.Path;
    //             var assemblyPdbPath = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

    //             var assembly = File.Exists(assemblyPdbPath) ?
    //                 Assembly.Load(File.ReadAllBytes(assemblyPath))
    //                 :
    //                 Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));

    //             var type = assembly.GetType(typeof(T).FullName);

    //             if (type == null)
    //                 return;

    //             var newComponent = (RxComponent)Activator.CreateInstance(type);

    //             if (newComponent != null)
    //             {
    //                 _rootComponent = newComponent;
    //                 Invalidate();
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             FireUnhandledExpectionEvent(ex);
    //         }
    //     }

    //     public override void Stop()
    //     {
    //         _hotReloadServer.Stop();

    //         base.Stop();
    //     }
    // }
}