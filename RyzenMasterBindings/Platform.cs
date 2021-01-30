using System;
using System.Runtime.InteropServices;

namespace RyzenMasterBindings
{
    public class Platform : IDisposable
    {
        private readonly IntPtr handle;
        private bool inited;

        private Platform(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            if (inited)
            {
                NativeMethods.Platform_UnInit(handle);
            }
        }

        public static Platform GetPlatform()
        {
            var instance = NativeMethods.GetPlatformWrapper();
            return new Platform(instance);
        }

        public bool Init()
        {
            inited = NativeMethods.Platform_Init(handle);

            return inited;
        }

        public DeviceManager GetDeviceManager()
        {
            var instance = NativeMethods.Platform_GetDeviceManager(handle);
            return new DeviceManager(instance);
        }

        private static class NativeMethods
        {
            [DllImport("RyzenMasterWrapper.dll")]
            public static extern IntPtr GetPlatformWrapper();

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Platform_Init(IntPtr @this);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Platform_UnInit(IntPtr @this);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern IntPtr Platform_GetDeviceManager(IntPtr @this);
        }
    }
}