# Description

This is a package to debug your VR Applications. It does not depend on any interaction SDKS like the Meta SDK
or the XR Interaction Toolkit of Unity.

# Features

- Virtual Reality Console
- Drawing debug shapes at runtime

# Virtual Reality Console

The virtual reality console at this point is pretty simple. Its just a 3D canvas that you can print message onto.
Keep in mind that before calling this function you should have the canvas in your scene to see anything.
You can do this quickly by right clicking in the hierarchy window and going:
VR Debug Package -> Virtual Reality Console

VirtualRealityConsole.PrintMessage(string message, PrintTypeVRC printType)

The print type can be:
- PrintTypeVRC.Clear. This clear the console and display then your message
- PrintTypeVRC.Append. This will add your message to your already existing messages.

# Drawing debug shapes

## Draw a cube
DebugDrawVR.DrawCube(Vector3 position, Quaternion rotation, Vecto3 scale, Color color);