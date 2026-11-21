## Contributing

Contributions are welcome! ⬇️

### Building from Source
1. Clone this repository.

2. Open the project in Visual Studio or Visual Studio Code (all required reference DLLs are already included in the `Libraries` folder).

3. Build the .csproj to generate `RE4ModdingAPI.dll`.

### Testing Your Changes
1. Extract **`csharp-api.zip`** from [REFramework Nightly Releases](https://github.com/praydog/REFramework-nightly/releases) into your Resident Evil 4 root game folder (if you haven't already).

2. Drop your newly built `RE4ModdingAPI.dll` into `reframework/plugins/managed/`.

3. Launch the game and verify your changes work cleanly across scene transitions and character swaps without throwing exceptions.

### Pull Request Guidelines
* Keep wrapper properties and methods intuitive and well-documented.

* Add null-checks and validity checks around RE Engine singletons and components so mods don't crash during loading screens or cutscenes.

* Include a brief example or usage snippet if you add a major new game system.
