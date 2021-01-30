#ifndef RYZENMASTERWRAPPER_LIBRARY_H
#define RYZENMASTERWRAPPER_LIBRARY_H

#include <IPlatform.h>
#include <IBIOSEx.h>
#include <ICPUEx.h>
#include "IDeviceManager.h"

#define RYZENMASTER_API __declspec(dllexport)

extern "C" RYZENMASTER_API IPlatform *GetPlatformWrapper();

extern "C" RYZENMASTER_API IDeviceManager *GetDeviceManagerWrapper();

extern "C" RYZENMASTER_API bool Platform_Init(IPlatform *platform);

extern "C" RYZENMASTER_API bool Platform_UnInit(IPlatform *platform);

extern "C" RYZENMASTER_API IDeviceManager *Platform_GetDeviceManager(IPlatform *platform);

extern "C" RYZENMASTER_API bool DeviceManager_Init(IDeviceManager *deviceManager);

extern "C" RYZENMASTER_API bool DeviceManager_UnInit(IDeviceManager *deviceManager);

extern "C" RYZENMASTER_API unsigned long DeviceManager_GetTotalDeviceCount(IDeviceManager *deviceManager);

extern "C" RYZENMASTER_API IDevice *DeviceManager_GetDevice(IDeviceManager *deviceManager, unsigned long index);

extern "C" RYZENMASTER_API void Device_GetName(IDevice *device, char *str, int capacity);

extern "C" RYZENMASTER_API void Device_GetDescription(IDevice *device, char *str, int capacity);

extern "C" RYZENMASTER_API void Device_GetVendor(IDevice *device, char *str, int capacity);

extern "C" RYZENMASTER_API void Device_GetRole(IDevice *device, char *str, int capacity);

extern "C" RYZENMASTER_API void Device_GetClassName(IDevice *device, char *str, int capacity);

extern "C" RYZENMASTER_API AOD_DEVICE_TYPE Device_GetType(IDevice *device);

extern "C" RYZENMASTER_API unsigned long Device_GetIndex(IDevice *device);

extern "C" RYZENMASTER_API int Bios_GetMemVDDIO(IBIOSEx *bios, unsigned short &value);

extern "C" RYZENMASTER_API int Bios_GetCurrentMemClock(IBIOSEx *bios, unsigned short &value);

extern "C" RYZENMASTER_API int Bios_GetMemCtrlTcl(IBIOSEx *bios, unsigned char &value);

extern "C" RYZENMASTER_API int Bios_GetMemCtrlTrcdrd(IBIOSEx *bios, unsigned char &value);

extern "C" RYZENMASTER_API int Bios_GetMemCtrlTras(IBIOSEx *bios, unsigned char &value);

extern "C" RYZENMASTER_API int Bios_GetMemCtrlTrp(IBIOSEx *bios, unsigned char &value);

extern "C" RYZENMASTER_API void Bios_GetVersion(IBIOSEx *bios, char *str, int capacity);

extern "C" RYZENMASTER_API void Bios_GetVendor(IBIOSEx *bios, char *str, int capacity);

extern "C" RYZENMASTER_API void Bios_GetDate(IBIOSEx *bios, char *str, int capacity);

extern "C" RYZENMASTER_API bool Cpu_GetL1DataCache(ICPUEx *cpu, CACHE_INFO &cacheInfo);

extern "C" RYZENMASTER_API bool Cpu_GetL1InstructionCache(ICPUEx *cpu, CACHE_INFO &cacheInfo);

extern "C" RYZENMASTER_API bool Cpu_GetL2Cache(ICPUEx *cpu, CACHE_INFO &cacheInfo);

extern "C" RYZENMASTER_API bool Cpu_GetL3Cache(ICPUEx *cpu, CACHE_INFO &cacheInfo);

extern "C" RYZENMASTER_API bool Cpu_GetCoreCount(ICPUEx *cpu, unsigned int &coreCount);

extern "C" RYZENMASTER_API bool Cpu_GetCorePark(ICPUEx *cpu, unsigned int &coreCount);

extern "C" RYZENMASTER_API void Cpu_GetPackage(ICPUEx *cpu, char *str, int capacity);

extern "C" RYZENMASTER_API bool Cpu_GetChipsetName(ICPUEx *cpu, char *str, int capacity);

extern "C" RYZENMASTER_API bool Cpu_GetCpuParameters(ICPUEx *cpu, CPUParameters &cpuParameters);

#endif //RYZENMASTERWRAPPER_LIBRARY_H
