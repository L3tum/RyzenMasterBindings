using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace RyzenMasterBindings
{
    public class Cpu : Device
    {
        internal Cpu(IntPtr native) : base(native)
        {
        }

        /// <summary>
        ///     Gets information on the L1 Data Cache
        /// </summary>
        /// <returns></returns>
        public CacheInfo? GetL1DataCacheInfo()
        {
            var cacheInfo = new CacheInfo();
            var success = NativeMethods.Cpu_GetL1DataCache(Handle, ref cacheInfo);

            if (success)
            {
                return cacheInfo;
            }

            RyzenMasterLibrary.Logger.LogError("L1D Failure");
            return null;
        }

        /// <summary>
        ///     Gets information on the L1 Instruction Cache
        /// </summary>
        /// <returns></returns>
        public CacheInfo? GetL1InstructionCacheInfo()
        {
            var cacheInfo = new CacheInfo();
            var success = NativeMethods.Cpu_GetL1InstructionCache(Handle, ref cacheInfo);

            if (success)
            {
                return cacheInfo;
            }

            RyzenMasterLibrary.Logger.LogError("L1I Failure");
            return null;
        }

        /// <summary>
        ///     Gets information on the L2 Cache
        /// </summary>
        /// <returns></returns>
        public CacheInfo? GetL2CacheInfo()
        {
            var cacheInfo = new CacheInfo();
            var success = NativeMethods.Cpu_GetL2Cache(Handle, ref cacheInfo);

            if (success)
            {
                return cacheInfo;
            }

            RyzenMasterLibrary.Logger.LogError("L2 Failure");
            return null;
        }

        /// <summary>
        ///     Gets information on the L3 Cache
        /// </summary>
        /// <returns></returns>
        public CacheInfo? GetL3CacheInfo()
        {
            var cacheInfo = new CacheInfo();
            var success = NativeMethods.Cpu_GetL3Cache(Handle, ref cacheInfo);

            if (success)
            {
                return cacheInfo;
            }

            RyzenMasterLibrary.Logger.LogError("L3 Failure");
            return null;
        }

        /// <summary>
        ///     Gets the number of physical cores
        /// </summary>
        /// <returns></returns>
        public uint? GetCoreCount()
        {
            uint value = 0;
            var success = NativeMethods.Cpu_GetCoreCount(Handle, ref value);

            if (success)
            {
                return value;
            }

            RyzenMasterLibrary.Logger.LogError("CoreCount Failure");
            return null;
        }

        /// <summary>
        ///     Gets the numbers of cores parked during the measuring interval
        /// </summary>
        /// <returns></returns>
        public uint? GetCorePark()
        {
            uint value = 0;
            var success = NativeMethods.Cpu_GetCorePark(Handle, ref value);

            if (success)
            {
                return value;
            }

            RyzenMasterLibrary.Logger.LogError("CorePark Failure");
            return null;
        }

        /// <summary>
        ///     Gets the package name, such as AM4
        /// </summary>
        /// <returns></returns>
        public string GetPackage()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Cpu_GetPackage(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the chipset name, such as AMD X570
        /// </summary>
        /// <returns></returns>
        public string GetChipsetName()
        {
            var sb = new StringBuilder(50);
            NativeMethods.Cpu_GetChipsetName(Handle, sb, sb.Capacity);

            return sb.ToString();
        }

        /// <summary>
        ///     Gets a structure containing information on current CPU values
        /// </summary>
        /// <returns></returns>
        public CPUParameters? GetCpuParameters()
        {
            var parameters = new CPUParameters();
            var success = NativeMethods.Cpu_GetCpuParameters(Handle, ref parameters);

            if (success)
            {
                return parameters;
            }

            RyzenMasterLibrary.Logger.LogError("CPUParameters Failure");
            return null;
        }

        private static class NativeMethods
        {
            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetL1DataCache(IntPtr @this, ref CacheInfo cacheInfo);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetL1InstructionCache(IntPtr @this, ref CacheInfo cacheInfo);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetL2Cache(IntPtr @this, ref CacheInfo cacheInfo);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetL3Cache(IntPtr @this, ref CacheInfo cacheInfo);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetCoreCount(IntPtr @this, ref uint coreCount);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetCorePark(IntPtr @this, ref uint coreCount);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Cpu_GetPackage(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern void Cpu_GetChipsetName(IntPtr @this, StringBuilder str, int capacity);

            [DllImport("RyzenMasterWrapper.dll")]
            public static extern bool Cpu_GetCpuParameters(IntPtr @this, ref CPUParameters cpuParameters);
        }
    }
}