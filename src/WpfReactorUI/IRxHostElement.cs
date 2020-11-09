
using System.Windows;

namespace WpfReactorUI
{
    public interface IRxHostElement
    {
        IRxHostElement Run();

        void Stop();

        Window ContainerWindow { get; }
    }
}