using System;

namespace WpfReactorUI.Internals
{
    public class AssemblyToReloadEventArgs : EventArgs
    {
        public AssemblyToReloadEventArgs(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}