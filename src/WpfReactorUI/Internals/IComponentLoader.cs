using System;

namespace WpfReactorUI.Internals
{
    internal interface IComponentLoader
    {
       RxComponent LoadComponent<T>() where T : RxComponent, new();

       event EventHandler ComponentAssemblyChanged;

       void Run();

       void Stop();
    }

    internal static class ComponentLoader
    {
        static IComponentLoader? _instance;
        public static IComponentLoader Instance
        {
            get => _instance ?? throw new InvalidOperationException("Component loader not available (is null)");
            set
            {
                if (_instance != null)
                    throw new InvalidOperationException();
                
                _instance = value;
            }
        }

    }
}