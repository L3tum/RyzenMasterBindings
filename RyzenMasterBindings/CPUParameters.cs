using System.Runtime.InteropServices;

namespace RyzenMasterBindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CPUParameters
    {
        /// <summary>
        ///     OC Mode
        /// </summary>
        public OCMode Mode;

        /// <summary>
        ///     Effective Frequency Data
        /// </summary>
        public EffectiveFrequencyData FrequencyData;

        /// <summary>
        ///     Peak Core Voltage
        /// </summary>
        public double PeakCoreVoltage;

        /// <summary>
        ///     SoC Voltage
        /// </summary>
        public double SocVoltage;

        /// <summary>
        ///     Current Temperature (C)
        /// </summary>
        public double Temperature;

        /// <summary>
        ///     Average core voltage over sample period
        /// </summary>
        public double AvgCoreVoltage;

        /// <summary>
        ///     Peak Speed of all active cores
        /// </summary>
        public double PeakSpeed;

        /// <summary>
        ///     PPT Limit (W)
        /// </summary>
        public float PPTLimit;

        /// <summary>
        ///     Current PPT Value (W)
        /// </summary>
        public float PPTValue;

        /// <summary>
        ///     TDC Limit (A)
        /// </summary>
        public float TDCLimit_VDD;

        /// <summary>
        ///     Current TDC Value (W)
        /// </summary>
        public float TDCValue_VDD;

        /// <summary>
        ///     EDC Limit (A)
        /// </summary>
        public float EDCLimit_VDD;

        /// <summary>
        ///     Current EDC Value (A)
        /// </summary>
        public float EDCValue_VDD;

        /// <summary>
        ///     cHTC Limit (C)
        /// </summary>
        public float cHTCLimit;

        /// <summary>
        ///     FCLK P0 Frequency
        /// </summary>
        public float FCLKP0Freq;

        /// <summary>
        ///     FCLK FMax Frequency (MHz)
        /// </summary>
        public float CCLK_Fmax;

        /// <summary>
        ///     TDC Limit SoC (A)
        /// </summary>
        public float TDCLimit_SOC;

        /// <summary>
        ///     Current TDC Value SoC (A)
        /// </summary>
        public float TDCValue_SOC;

        /// <summary>
        ///     EDC Limit SoC (A)
        /// </summary>
        public float EDCLimit_SOC;

        /// <summary>
        ///     Current EDC Value SoC (A)
        /// </summary>
        public float EDCValue_SOC;

        /// <summary>
        ///     VDDCR VOD Power (W)
        /// </summary>
        public float VDDCR_VDD_Power;

        /// <summary>
        ///     VDDCR SoC Power (W)
        /// </summary>
        public float VDDCR_SOC_Power;
    }
}