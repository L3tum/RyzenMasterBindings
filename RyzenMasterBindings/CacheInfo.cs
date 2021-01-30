using System.Runtime.InteropServices;

namespace RyzenMasterBindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CacheInfo
    {
        /// <summary>
        ///     Cache size (KB)
        /// </summary>
        public double Size;

        /// <summary>
        ///     Cache associativity
        /// </summary>
        public double Associativity;

        /// <summary>
        ///     Cache lines per tag
        /// </summary>
        public double Lines;

        /// <summary>
        ///     Cache line size (bytes)
        /// </summary>
        public double LineSize;

        public override string ToString()
        {
            return $"Size: {Size}, Associativity: {Associativity}, Lines: {Lines}, LineSize: {LineSize}";
        }
    }
}