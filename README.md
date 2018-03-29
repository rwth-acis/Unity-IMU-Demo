# Unity IMU Demo

This demo shows how to use MQTT data of an IMU to set an object's orientation.

The following steps have already been performed in this project but are documented here for future reference:

## MQTT Setup

The MQTT Client uses [this](https://github.com/eclipse/paho.mqtt.m2mqtt) library since it supports UWP apps which run on the HoloLens.
### Building the M2MQTT library
1. Downlod the source code from https://github.com/eclipse/paho.mqtt.m2mqtt
2. Open its Visual Studio solution. There should be five projects but only the .NET and .WinRT projects are relevant. 

> The other projects might display warnings for missing components and references but there is no need to install additional components for them since they are not used.
3. Open the *Properties* of the .NET Project and under *Application* set the Target Framework to 3.5
![Properties settings](/Documentation/Images/TargetFramework.png)

5. Build the two projects
> You might encounter errors concerning the TLS versions in a switch-case block of the file `MqttNetworkChannel.cs`. Since it is not needed, comment out the two cases which show errors.
6. Open a file browser and navigate to the subfolder `obj/Debug`.  It contains the dll-files `M2Mqtt.Net.dll` and `M2Mqtt.WinRT.dll` which need to be integrated into the Unity project.

### Import the generated DLLs into the Unity project

The DLLs are imported as Plugins. Plugins need to be placed in the folder `Assets/Plugins`. Additionally, the folder structure indicates for which platform the plugin works.

> For the final UWP app, the M2Mqtt.Net.dll file not required. It is only added to the project in order to debug the MQTT functionality in the editor.

1. Create the folder `Assets/Plugins` in the Unity project.
2. Copy the file `M2Mqtt.Net.dll` into the created folder.
3. Open the Unity Editor, navigate to the copied file and change its settings in Unity's Inspector to *Editor*.
![.NET dll settings](/Documentation/Images/M2MQTT_NetSettings.png)
4. In the Plugins folder, create a subfolder named `WSA`.
5. Copy the file `M2Mqtt.WinRT.dll` to this new subfolder.
6. In Unity's Editor change the settings of the dll in the Inspector to *WSAPlayer*.
![.NET dll settings](/Documentation/Images/M2MQTT_WinRTSettings.png)
