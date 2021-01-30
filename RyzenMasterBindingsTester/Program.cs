using System;
using Microsoft.Extensions.Logging.Abstractions;
using RyzenMasterBindings;

namespace RyzenMasterBindingsTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(RyzenMasterLibrary.Init(NullLogger.Instance));
            using var platform = Platform.GetPlatform();
            Console.WriteLine(platform.Init());
            var deviceManager = platform.GetDeviceManager();
            Console.WriteLine(deviceManager.GetTotalDeviceCount());

            for (var i = 0u; i < deviceManager.GetTotalDeviceCount(); i++)
            {
                var device = deviceManager.GetDevice(i);
                Console.WriteLine("-----");
                Console.WriteLine("Index: {0}", i);
                Console.WriteLine("Name: {0}", device.GetName());
                Console.WriteLine("Description: {0}", device.GetDescription());
                Console.WriteLine("Vendor: {0}", device.GetVendor());
                Console.WriteLine("Role: {0}", device.GetRole());
                Console.WriteLine("ClassName: {0}", device.GetClassName());
                Console.WriteLine("DeviceType: {0}", device.GetDeviceType());
                Console.WriteLine("Index (API): {0}", device.GetIndex());

                if (device.GetDeviceType() == DeviceType.DT_BIOS)
                {
                    var bios = device.AsBios();
                    Console.WriteLine("Mem VDDIO: {0}", bios.GetMemVDDIO());
                    Console.WriteLine("Mem Clock: {0}", bios.GetCurrentMemClock());
                    Console.WriteLine("Mem CTRL TCL: {0}", bios.GetMemCtrlTcl());
                    Console.WriteLine("Mem CTRL Trcdrd: {0}", bios.GetMemCtrlTrcdrd());
                    Console.WriteLine("Mem CTRL Tras: {0}", bios.GetMemCtrlTras());
                    Console.WriteLine("Mem CTRL Trp: {0}", bios.GetMemCtrlTrp());
                    Console.WriteLine("Version: {0}", bios.GetVersion());
                    Console.WriteLine("Vendor: {0}", bios.GetVendor());
                    Console.WriteLine("Date: {0}", bios.GetDate());
                }
                else if (device.GetDeviceType() == DeviceType.DT_CPU)
                {
                    var cpu = device.AsCpu();
                    Console.WriteLine("L1D: {0}", cpu.GetL1DataCacheInfo()?.ToString());
                    Console.WriteLine("L1I: {0}", cpu.GetL1InstructionCacheInfo()?.ToString());
                    Console.WriteLine("L2: {0}", cpu.GetL2CacheInfo()?.ToString());
                    Console.WriteLine("L3: {0}", cpu.GetL3CacheInfo()?.ToString());
                    Console.WriteLine("CoreCount: {0}", cpu.GetCoreCount());
                    Console.WriteLine("CorePark: {0}", cpu.GetCorePark());
                    Console.WriteLine("Package: {0}", cpu.GetPackage());
                    Console.WriteLine("Chipset: {0}", cpu.GetChipsetName());
                    Console.WriteLine("PeakCoreSpeed: {0}", cpu.GetCpuParameters()?.PeakSpeed);
                    Console.WriteLine("OCMode: {0}", cpu.GetCpuParameters()?.Mode.Flags);
                }
            }

            RyzenMasterLibrary.UnInit();
        }
    }
}