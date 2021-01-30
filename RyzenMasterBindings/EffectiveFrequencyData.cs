using System;
using System.Runtime.InteropServices;

namespace RyzenMasterBindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EffectiveFrequencyData
    {
        /// <summary>
        ///     Array of effective frequency in Mhz
        /// </summary>
        public IntPtr Freq;

        /// <summary>
        ///     Array of the C0 State Residency in %
        /// </summary>
        public IntPtr State;

        /// <summary>
        ///     Length of the Array
        /// </summary>
        public uint Length;

        public double GetFreq(uint index)
        {
            if (index < Length)
            {
                var managedArray = new double[Length];
                Marshal.Copy(Freq, managedArray, 0, (int) Length);

                return managedArray[index];
            }

            return 0.0;
        }

        public double GetState(uint index)
        {
            if (index < Length)
            {
                var managedArray = new double[Length];
                Marshal.Copy(State, managedArray, 0, (int) Length);

                return managedArray[index];
            }

            return 0.0;
        }
    }
}