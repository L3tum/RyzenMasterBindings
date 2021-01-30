using System;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace RyzenMasterBindings
{
    public static class RyzenMasterLibrary
    {
        private static IntPtr handle;
        internal static ILogger Logger = null!;

        public static bool Init(ILogger? logger = null)
        {
            logger ??= NullLogger.Instance;
            Logger = logger;

            // Check if already initialized
            if (handle != IntPtr.Zero)
            {
                return true;
            }

            // Check for Windows
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                logger.LogCritical("Library only works on Windows");
                return false;
            }

            // Check for admin rights
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    return false;
                }
            }

            // Check for running driver
            using var mso =
                new ManagementObjectSearcher("SELECT * FROM Win32_SystemDriver where Name='AMDRyzenMasterDriverV16'");
            var drivers = mso.Get();

            if (drivers.Count == 0)
            {
                return false;
            }

            foreach (var driver in drivers)
            {
                if ((string) driver.Properties["State"].Value != "Running")
                {
                    return false;
                }
            }

            return LoadLibraryFromResources("RyzenMasterBindings.RyzenMasterWrapper.dll", "RyzenMasterWrapper.dll");
        }

        public static bool UnInit()
        {
            if (handle == IntPtr.Zero)
            {
                return false;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                NativeMethods.FreeLibrary(handle);
            }
            else
            {
                NativeMethods.dlclose(handle);
            }

            return true;
        }

        /// <summary>
        ///     Loads a native library from embedded resources
        /// </summary>
        /// <param name="libraryResourceName"></param>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        private static bool LoadLibraryFromResources(string libraryResourceName, string libraryName)
        {
            var assembly = Assembly.GetAssembly(typeof(RyzenMasterLibrary));
            using var stream = assembly.GetManifestResourceStream(libraryResourceName);

            if (stream == null)
            {
                return false;
            }

            var dllPath = Path.GetDirectoryName(assembly.Location);
            dllPath = Path.Combine(dllPath, libraryName);
            var data = new BinaryReader(stream).ReadBytes((int) stream.Length);
            File.WriteAllBytes(dllPath, data);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                handle = NativeMethods.LoadLibrary(dllPath);
            }
            else
            {
                handle = NativeMethods.dlopen(dllPath, 0);
            }

            return true;
        }

        private static class NativeMethods
        {
            [DllImport("kernel32", SetLastError = true)]
            internal static extern IntPtr LoadLibrary(string fileName);

            [DllImport("kernel32", SetLastError = true)]
            internal static extern void FreeLibrary(IntPtr handle);

            [DllImport("libdl")]
            internal static extern IntPtr dlopen(string fileName, int flag);

            [DllImport("libdl")]
            internal static extern int dlclose(IntPtr handle);
        }
    }
}