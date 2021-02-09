using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.Internals
{
    internal class Utils
    {
        public static byte[] ReadFileBytesWithoutLock(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace", nameof(path));
            }

            byte[] buffer;
            using (System.IO.FileStream fs = System.IO.File.Open(
                path,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read,
                System.IO.FileShare.ReadWrite))
            {
                int numBytesToRead = Convert.ToInt32(fs.Length);
                buffer = new byte[(numBytesToRead)];
                fs.Read(buffer, 0, numBytesToRead);
            }

            return buffer;
        }

        public static Assembly LoadAssemblyWithoutLock(string assemblyPath)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
            {
                throw new ArgumentException($"'{nameof(assemblyPath)}' cannot be null or whitespace", nameof(assemblyPath));
            }

            string folderPath = Path.GetDirectoryName(assemblyPath) ?? throw new InvalidOperationException($"Unable to get path of the assembly {assemblyPath}");
            string assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);
            var assemblyPdbPath = Path.Combine(folderPath, assemblyName + ".pdb");


            Assembly assembly;
            if (!File.Exists(assemblyPdbPath))
            {
                assembly = Assembly.Load(ReadFileBytesWithoutLock(assemblyPath));
                Trace.WriteLine($"[WpfReactorUI] Assembly '{assemblyPath}' loaded");
            }
            else
            {
                var pdbBuffer = ReadFileBytesWithoutLock(assemblyPdbPath);
                File.Delete(assemblyPdbPath);
                //var ghostAssemblyFilePath = Path.Combine(folderPath, assemblyName + "_ghost.pdb");
                //File.Move(assemblyPdbPath, ghostAssemblyFilePath, true);
                //Trace.WriteLine($"[WpfReactorUI] Assembly pdb '{assemblyPdbPath}' loaded from {ghostAssemblyFilePath}");
                assembly = Assembly.Load(ReadFileBytesWithoutLock(assemblyPath), pdbBuffer);
                Trace.WriteLine($"[WpfReactorUI] Assembly '{assemblyPath}' loaded");
                Trace.WriteLine($"[WpfReactorUI] Assembly pdb '{assemblyPdbPath}' loaded");

                //File.WriteAllBytes(assemblyPdbPath, Array.Empty<byte>());
            }

            return assembly;
        }

        public static void CreateEmptyDummyPdbFile(string assemblyPath)
        {
            string assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);
            string folderPath = Path.GetDirectoryName(assemblyPath) ?? throw new InvalidOperationException($"Unable to get path of the assembly {assemblyPath}");
            var assemblyPdbPath = Path.Combine(folderPath, assemblyName + ".pdb");
            File.WriteAllBytes(assemblyPdbPath, Array.Empty<byte>());
        }
    }
}
