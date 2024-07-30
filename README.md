# UnrealRS2

This project aims to reproduce the rs2 engine (client) in c# while also using Unreal Engine 5 as the renderer


# Requirements

Unreal SDK 5.4.3
.NET SDK 8.0
Rider or Visual Studio (latest version of build tools recommended)
[UnrealSharp Third Party libs installed to project](https://github.com/bodong1987/UnrealSharp/blob/main/Docs/PrepareThirdParty.md)

## Installation

First you will open the unreal project in UDK, then go to Tools -> UnrealSharp -> Export C++ Database
Then, you can open the .NET project located in GameScripts and build twice. You should now have a successful build of the project.
