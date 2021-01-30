using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace RyzenMasterBindings
{
    public class Bios : Device
    {
        internal Bios(IntPtr native) : base(native)
        {
        }

        /// <summary>
        ///     Gets the current memory VDDIO voltage supply value in millivolts
        /// </summary>
        /// <returns></returns>
        public ushort? GetMemVDDIO()
        {
            ushort value = 0;
            var success = NativeMethods.Bios_GetMemVDDIO(Handle, ref value);

            if (success != 0)
            {
                RyzenMasterLibrary.Logger.LogError("MemVDDIO Failure: {0}", success);
                return null;
            }

            return value;
        }

        /// <summary>
        ///     Gets the current memory clock frequency in MHz
        /// </summary>
        /// <returns></returns>
        public ushort? GetCurrentMemClock()
        {
            ushort value = 0;
            var success = NativeMethods.Bios_GetCurrentMemClock(Handle, ref value);

            if (success != 0)
            {
                RyzenMasterLibrary.Logger.LogError("MemClock Failure: {0}", success);
                return null;
            }

            return value;
        }

        /// <summary>
        ///     Gets the current memory CAS latency
        /// </summary>
        /// <returns></returns>
        public byte? GetMemCtrlTcl()
        {
            byte value = 0;
            var success = NativeMethods.Bios_GetMemCtrlTcl(Handle, ref value);

            if (success != 0)
            {
                RyzenMasterLibrary.Logger.LogError("MemCtrlTcl Failure: {0}", success);
                return null;
            }

            return value;
        }

        /// <summary>
        ///     Gets the current memory read row address to column address delay
        /// </summary>
        /// <returns></returns>
        public byte? GetMemCtrlTrcdrd()
        {
            byte value = 0;
            var success = NativeMethods.Bios_GetMemCtrlTrcdrd(Handle, ref value);

            if (success != 0)
            {
                RyzenMasterLibrary.Logger.LogError("MemCtrlTrcdrd Failure: {0}", success);
                return null;
            }

            return value;
        }

        /// <summary>
        ///     Gets the current memory row active time
        /// </summary>
        /// <returns></returns>
        public byte? GetMemCtrlTras()
        {
            byte value = 0;
            var success = NativeMethods.Bios_GetMemCtrlTras(Handle, ref value);

            if (success != 0)
            {
                RyzenMasterLibrary.Logger.LogError("MemCtrlTras Failure: {0}", success);
                return null;
            }

            return value;
        }

        /// <summary>
        ///     Gets the current memory row pre-charge delay
        /// </summary>
        /// <returns></returns>
        public byte? GetMemCtrlTrp()
        {
            byte value = 0;
            var success = NativeMethods.Bios_GetMemCtrlTrp(Handle, ref value);

            if (success != 0)
            {
                RyzenMasterLibrary.Logger.LogError("MemCtrlTrp Failure: {0}", success);
                return null;
            }

            return value;
        }

        /// <summary>
        ///     Gets the version of this BIOS
        /// </summary>
        /// <returns></returns>
        public string GetVersion()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Bios_GetVersion(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the vendor of this BIOS
        /// </summary>
        /// <returns></returns>
        public new string GetVendor()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Bios_GetVendor(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the date this BIOS was released
        /// </summary>
        /// <returns></returns>
        public string GetDate()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Bios_GetDate(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        private static class NativeMethods
        {
            [DllImport("RyzenMasterWrapper.dll")]
            public static extern int Bios_GetMemVDDIO(IntPtr handle, ref ushort value);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern int Bios_GetCurrentMemClock(IntPtr handle, ref ushort value);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern int Bios_GetMemCtrlTcl(IntPtr handle, ref byte value);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern int Bios_GetMemCtrlTrcdrd(IntPtr handle, ref byte value);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern int Bios_GetMemCtrlTras(IntPtr handle, ref byte value);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern int Bios_GetMemCtrlTrp(IntPtr handle, ref byte value);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Bios_GetVersion(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Bios_GetVendor(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Bios_GetDate(IntPtr @this, StringBuilder str, int capacity);
        }
    }
}