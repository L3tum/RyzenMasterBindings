using System;
using System.Runtime.InteropServices;

namespace RyzenMasterBindings
{
    [StructLayout(LayoutKind.Explicit)]
    public struct OCMode
    {
        [FieldOffset(0)] public uint Mode;
        [FieldOffset(0)] public OCModeFlags Flags;
    }

    [Flags]
    public enum OCModeFlags
    {
        /// <summary>
        ///     Auto or Default Mode
        /// </summary>
        AUTO = 0b1,

        /// <summary>
        ///     Manual Overclocking Mode
        /// </summary>
        MANUAL = 0b10,

        /// <summary>
        ///     PBO Mode
        /// </summary>
        PBO_MODE = 0b100,

        /// <summary>
        ///     AutoOverclocking Mode
        /// </summary>
        AUTO_OVERCLOCKING = 0b1000,
        RESERVED = int.MaxValue << 4
    }
}