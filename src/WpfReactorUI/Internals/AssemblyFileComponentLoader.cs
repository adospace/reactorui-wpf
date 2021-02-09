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
        private FileSystemWatcher? _fileSystemWatcher;

        public AssemblyFileComponentLoader(string assemblyFileName)
        {
            if (string.IsNullOrWhiteSpace(assemblyFileName))
            {
                throw new ArgumentException($"'{nameof(assemblyFileName)}' can't be null or empty", nameof(assemblyFileName));
            }

            _assemblyFileName = Path.GetFullPath(assemblyFileName);
        }

        public event EventHandler? ComponentAssemblyChanged;

        public RxComponent LoadComponent<T>() where T : RxComponent, new()
        {
            var assemblyPath = _assemblyFileName;
            var assemblyPdbPath = Path.Combine(
                Path.GetDirectoryName(assemblyPath) ?? throw new InvalidOperationException($"Unable to get directory name of {assemblyPath}"), 
                Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            //var assembly = File.Exists(assemblyPdbPath) ?
            //    Assembly.Load(Utils.ReadFileBytesWithoutLock(assemblyPath))
            //    :
            //    Assembly.Load(Utils.ReadFileBytesWithoutLock(assemblyPath), Utils.ReadFileBytesWithoutLock(assemblyPdbPath));

            var assembly = Utils.LoadAssemblyWithoutLock(assemblyPath);

            var type = assembly.GetType(typeof(T).FullName ?? throw new InvalidOperationException("Unable to get component type full name"))
                ?? throw new InvalidOperationException("Unable to get type of the component to load");

            return (RxComponent)(Activator.CreateInstance(type) ?? throw new InvalidOperationException($"Unable to create instance of type {type}"));
        }

        public void Run()
        {
            _fileSystemWatcher = new FileSystemWatcher(
                Path.GetDirectoryName(_assemblyFileName) ?? throw new InvalidOperationException($"Unable to get directory name of {_assemblyFileName}"),
                "*.dll")
            {
                NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
            };

            _fileSystemWatcher.Changed += OnAssemblyFileChanged;

            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void OnAssemblyFileChanged(object sender, FileSystemEventArgs e)
        {
            if (Path.GetFullPath(e.FullPath) != Path.GetFullPath(_assemblyFileName))
                return;
            if (_fileSystemWatcher == null)
            {
                return;
            }

            _fileSystemWatcher.EnableRaisingEvents = false;

            try
            {
                Thread.Sleep(2000);
                ComponentAssemblyChanged?.Invoke(this, EventArgs.Empty);
            }
            finally
            {
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        public void Stop()
        {
            if (_fileSystemWatcher == null)
            {
                return;
            }

            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Changed -= OnAssemblyFileChanged;
            _fileSystemWatcher.Dispose();
            _fileSystemWatcher = null;
        }
    }
}