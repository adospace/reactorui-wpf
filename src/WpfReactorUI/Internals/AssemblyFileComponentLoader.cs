using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfReactorUI.Internals
{
    internal class AssemblyFileComponentLoader : IComponentLoader
    {
        private readonly string _assemblyFileName;
        private FileSystemWatcher _fileSystemWatcher;

        public AssemblyFileComponentLoader(string assemblyFileName)
        {
            if (string.IsNullOrWhiteSpace(assemblyFileName))
            {
                throw new ArgumentException($"'{nameof(assemblyFileName)}' can't be null or empty", nameof(assemblyFileName));
            }

            _assemblyFileName = assemblyFileName;
        }

        public event EventHandler ComponentAssemblyChanged;

        public RxComponent LoadComponent<T>() where T : RxComponent, new()
        {
            var assemblyPath = _assemblyFileName;
            var assemblyPdbPath = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            var assembly = File.Exists(assemblyPdbPath) ?
                Assembly.Load(File.ReadAllBytes(assemblyPath))
                :
                Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));

            var type = assembly.GetType(typeof(T).FullName);

            return (RxComponent)Activator.CreateInstance(type);
        }

        public void Run()
        {
            _fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(_assemblyFileName), "*.dll");
            _fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite;

            _fileSystemWatcher.Changed += OnAssemblyFileChanged;

            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private async void OnAssemblyFileChanged(object sender, FileSystemEventArgs e)
        {
            if (Path.GetFullPath(e.FullPath) != Path.GetFullPath(_assemblyFileName))
                return;

            _fileSystemWatcher.EnableRaisingEvents = false;

            try
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(()=>
                    ComponentAssemblyChanged?.Invoke(this, EventArgs.Empty));
            }
            finally
            {
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        public void Stop()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Changed -= OnAssemblyFileChanged;
            _fileSystemWatcher.Dispose();
        }
    }
}