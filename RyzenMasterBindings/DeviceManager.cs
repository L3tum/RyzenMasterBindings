using System;
using System.Runtime.InteropServices;

namespace RyzenMasterBindings
{
    public class DeviceManager
    {
        private readonly IntPtr handle;

        internal DeviceManager(IntPtr handle)
        {
            this.handle = handle;
        }

        public ulong GetTotalDeviceCount()
        {
            return NativeMethods.DeviceManager_GetTotalDeviceCount(handle);
        }

        public Device GetDevice(ulong index)
        {
            var instance = NativeMethods.DeviceManager_GetDevice(handle, index);
            return new Device(instance);
        }

        private static class NativeMethods
        {
            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool DeviceManager_Init(IntPtr @this);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool DeviceManager_UnInit(IntPtr @this);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern IntPtr GetDeviceManagerWrapper();

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern ulong DeviceManager_GetTotalDeviceCount(IntPtr @this);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern IntPtr DeviceManager_GetDevice(IntPtr @this, ulong index);
        }
    }
}