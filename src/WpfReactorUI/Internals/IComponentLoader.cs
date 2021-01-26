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
        public static IComponentLoader? Instance
        {
            get => _instance;
            set
            {
                if (_instance != null && value != null && _instance != value)
                    throw new InvalidOperationException();
                
                _instance = value;
            }
        }

    }
}