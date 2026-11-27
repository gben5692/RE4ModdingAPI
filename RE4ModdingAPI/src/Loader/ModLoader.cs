using System.Runtime.Loader;
using REFrameworkNET;

namespace RE4ModdingAPI.Loader;

internal class ModLoader // this class will handle loading plugins from a folder
{
    private readonly string PluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
    public readonly List<Plugin> LoadedPlugins = [];

    public void LoadPlugins()
    {
        API.LogInfo($"[API] Loading plugins from path: {Path.GetFullPath(PluginsPath)}");

        try
        {
            if (!Directory.Exists(PluginsPath))
            Directory.CreateDirectory(PluginsPath);

            foreach (var file in Directory.GetFiles(PluginsPath))
            {
                if (Path.GetExtension(file) == ".dll")
                {
                    var context = AssemblyLoadContext.GetLoadContext(typeof(Plugin).Assembly)!;
                    using var memoryStream = new MemoryStream(File.ReadAllBytes(file)); 
                    var loadedAssembly = context.LoadFromStream(memoryStream);

                    foreach (var type in loadedAssembly.GetTypes())
                    {
                        if (type.IsSubclassOf(typeof(Plugin)) && type.IsClass)
                        {
                            Plugin? plugin = (Plugin?)Activator.CreateInstance(type);
                            LoadedPlugins.Add(plugin!);

                            API.LogInfo($"[API] Loaded Plugin: {plugin!.Name}, by: {plugin!.Author}, v{plugin!.Version}");

                            plugin.OnEnabled();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            API.LogError($"[API] Error in trying to load plugins with the error: {ex}");
        }
    }

    public void UnloadPlugins()
    {
        LoadedPlugins.Clear();
    }
}