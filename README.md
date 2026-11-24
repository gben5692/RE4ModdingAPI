## RE4 Modding API

### Why? 
REFramework makes it difficult to subscribe to events and hook internal game methods, so I built a high-level C# wrapper to make developing Resident Evil 4 Remake mods simple

### Installation
1. Download **`csharp-api.zip`** from [REFramework Nightly Releases](https://github.com/praydog/REFramework-nightly/releases) and extract it into your Resident Evil 4 root game folder.
2. Download `RE4ModdingAPI.dll` from the releases.
3. Place `RE4ModdingAPI.dll` into your `reframework/plugins/managed/` folder.

### Creating a Mod
1. Create a new C# Class Library project targeting **.NET 10**.
2. Add references to `RE4ModdingAPI.dll` and the required DLLs from the `Libraries` folder.
3. Check out the `Examples` folder to see how to implement `OnEnabled` and `OnUpdate` etc.
4. Build your project and drop your compiled mod `.dll` into the `Plugins` folder in the game's root directory (where the `.exe` is located).


### Requirements
* .NET 10
* [REFramework](https://github.com/praydog/REFramework) (with C# / .NET support)

### Credits
*  Built on top of [praydog/REFramework](https://github.com/praydog/REFramework)

