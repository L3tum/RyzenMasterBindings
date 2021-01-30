using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RyzenMasterBindings
{
    public class Device : IDisposable
    {
        protected IntPtr Handle;

        internal Device(IntPtr native)
        {
            Handle = native;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Gets the current device as BIOS (check DeviceType first)
        /// </summary>
        /// <returns></returns>
        public Bios AsBios()
        {
            return new Bios(Handle);
        }

        /// <summary>
        ///     Gets the current device as CPU (check DeviceType first)
        /// </summary>
        /// <returns></returns>
        public Cpu AsCpu()
        {
            return new Cpu(Handle);
        }

        /// <summary>
        ///     Gets the name of this device
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Device_GetName(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the description of this device
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            var sb = new StringBuilder(100);
            NativeMethods.Device_GetDescription(Handle, sb, sb.Capacity);

            return sb.ToString();
        }


        /// <summary>
        ///     Gets the vendor of this device
        /// </summary>
        /// <returns></returns>
        public string GetVendor()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Device_GetVendor(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the role of this device in the computer
        /// </summary>
        /// <returns></returns>
        public string GetRole()
        {
            var sb = new StringBuilder(100);
            NativeMethods.Device_GetRole(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the class name of this device
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Device_GetClassName(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the device type in order to check whether it's CPU or BIOS
        /// </summary>
        /// <returns></returns>
        public DeviceType GetDeviceType()
        {
            return NativeMethods.Device_GetType(Handle);
        }

        /// <summary>
        ///     Gets the index of the device
        ///     NOTE: In my testing, this doesn't work
        /// </summary>
        /// <returns></returns>
        public ulong GetIndex()
        {
            return NativeMethods.Device_GetIndex(Handle);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Handle != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Handle);
                Handle = IntPtr.Zero;
            }
        }

        private static class NativeMethods
        {
            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Device_GetName(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Device_GetDescription(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Device_GetVendor(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Device_GetRole(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Device_GetClassName(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern DeviceType Device_GetType(IntPtr @this);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern ulong Device_GetIndex(IntPtr @this);
        }
    }
}