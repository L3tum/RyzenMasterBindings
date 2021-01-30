# RyzenMasterBindings

### Important Notice

This software uses headers and libs distributed as part of the Ryzen Master SDK. The license agreement can be seen (
here)[RyzenMasterWrapper/external/ryzenmasterlibs/License.rtf].

Unfortunately, due to the restrictiveness of the license (and my limited knowledge of copyright law), I am not able to
redistribute the header files nor the object files required to build this project completely. However, you can go to (
the download page)[https://developer.amd.com/amd-ryzentm-master-monitoring-sdk/] for the SDK and download it yourself.
You'll then need to place the *.LIB and *.H files in its respective directories inside of (
RyzenMasterWrapper)[RyzenMasterWrapper/external].

## Usage

You can include this library like any other library in your .NET projects. In order to initialize the library you need
to call

```c#
bool RyzenMasterLibrary.Init(ILogger? logger = null)
```

You can ignore the logger parameter for now. It's mostly for use as a debugging utility.

Following that, you'll want to call the method

````c#
Platform Platform.GetPlatform()
````

It will return a Platform class that gives access to the installed devices.

You can then enumerate the installed devices with

````c#
DeviceManager Platform.GetDeviceManager()
Device DeviceManager.GetDevice(index)
````

Each device has an associated `DeviceType`. Using this device type can give you access to further specific device
information.

````c#
Bios Device.AsBios()
Cpu Device.AsCpu()
````

## License

This software is distributed under the MIT License. Any external software used is distributed under its respective
license agreement included in its respective directory.