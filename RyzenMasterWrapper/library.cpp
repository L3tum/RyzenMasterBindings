#include "library.h"

#include <iostream>

IPlatform *GetPlatformWrapper() {
    return &GetPlatform();
}

IDeviceManager *GetDeviceManagerWrapper() {
    return &GetDeviceManager();
}

bool Platform_Init(IPlatform *platform) {
    return platform->Init(NULL);
}

bool Platform_UnInit(IPlatform *platform) {
    return platform->UnInit();
}

IDeviceManager *Platform_GetDeviceManager(IPlatform *platform) {
    return &platform->GetIDeviceManager();
}

bool DeviceManager_Init(IDeviceManager *deviceManager) {
    return deviceManager->Init(NULL);
}

bool DeviceManager_UnInit(IDeviceManager *deviceManager) {
    return deviceManager->UnInit();
}

unsigned long DeviceManager_GetTotalDeviceCount(IDeviceManager *deviceManager) {
    return deviceManager->GetTotalDeviceCount();
}

IDevice *DeviceManager_GetDevice(IDeviceManager *deviceManager, unsigned long index) {
    return deviceManager->GetDevice(index);
}

void Device_GetName(IDevice *device, char *str, int capacity) {
    auto name = device->GetName();
    wcstombs(str, name, capacity);
}

void Device_GetDescription(IDevice *device, char *str, int capacity) {
    auto name = device->GetDescription();
    wcstombs(str, name, capacity);
}

void Device_GetVendor(IDevice *device, char *str, int capacity) {
    auto name = device->GetVendor();
    wcstombs(str, name, capacity);
}

void Device_GetRole(IDevice *device, char *str, int capacity) {
    auto name = device->GetRole();
    wcstombs(str, name, capacity);
}

void Device_GetClassName(IDevice *device, char *str, int capacity) {
    auto name = device->GetClassName();
    wcstombs(str, name, capacity);
}

AOD_DEVICE_TYPE Device_GetType(IDevice *device) {
    return device->GetType();
}

unsigned long Device_GetIndex(IDevice *device) {
    return device->GetIndex();
}

int Bios_GetMemVDDIO(IBIOSEx *bios, unsigned short &value) {
    return bios->GetMemVDDIO(value);
}

int Bios_GetCurrentMemClock(IBIOSEx *bios, unsigned short &value) {
    return bios->GetCurrentMemClock(value);
}

int Bios_GetMemCtrlTcl(IBIOSEx *bios, unsigned char &value) {
    return bios->GetMemCtrlTcl(value);
}

int Bios_GetMemCtrlTrcdrd(IBIOSEx *bios, unsigned char &value) {
    return bios->GetMemCtrlTrcdrd(value);
}

int Bios_GetMemCtrlTras(IBIOSEx *bios, unsigned char &value) {
    return bios->GetMemCtrlTras(value);
}

int Bios_GetMemCtrlTrp(IBIOSEx *bios, unsigned char &value) {
    return bios->GetMemCtrlTrp(value);
}

void Bios_GetVersion(IBIOSEx *bios, char *str, int capacity) {
    auto name = bios->GetVersion();
    wcstombs(str, name, capacity);
}

void Bios_GetVendor(IBIOSEx *bios, char *str, int capacity) {
    auto name = bios->GetVendor();
    wcstombs(str, name, capacity);
}

void Bios_GetDate(IBIOSEx *bios, char *str, int capacity) {
    auto name = bios->GetDate();
    wcstombs(str, name, capacity);
}

bool Cpu_GetL1DataCache(ICPUEx *cpu, CACHE_INFO &cacheInfo) {
    auto success = cpu->GetL1DataCache(cacheInfo);

    return success == 0;
}

bool Cpu_GetL1InstructionCache(ICPUEx *cpu, CACHE_INFO &cacheInfo) {
    auto success = cpu->GetL1InstructionCache(cacheInfo);

    return success == 0;
}

bool Cpu_GetL2Cache(ICPUEx *cpu, CACHE_INFO &cacheInfo) {
    auto success = cpu->GetL2Cache(cacheInfo);

    return success == 0;
}

bool Cpu_GetL3Cache(ICPUEx *cpu, CACHE_INFO &cacheInfo) {
    auto success = cpu->GetL3Cache(cacheInfo);

    return success == 0;
}

bool Cpu_GetCoreCount(ICPUEx *cpu, unsigned int &coreCount) {
    auto success = cpu->GetCoreCount(coreCount);

    return success == 0;
}

bool Cpu_GetCorePark(ICPUEx *cpu, unsigned int &coreCount) {
    auto success = cpu->GetCorePark(coreCount);

    return success == 0;
}

void Cpu_GetPackage(ICPUEx *cpu, char *str, int capacity) {
    auto name = cpu->GetPackage();
    wcstombs(str, name, capacity);
}

bool Cpu_GetChipsetName(ICPUEx *cpu, char *str, int capacity) {
    auto name = new wchar_t[capacity];
    auto success = cpu->GetChipsetName(name);

    if (success == 0) {
        wcstombs(str, name, capacity);
    }

    return success == 0;
}

bool Cpu_GetCpuParameters(ICPUEx *cpu, CPUParameters &cpuParameters) {
    auto success = cpu->GetCPUParameters(cpuParameters);

    return success == 0;
}
