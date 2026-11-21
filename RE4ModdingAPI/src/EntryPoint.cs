using RE4ModdingAPI.Loader;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;
using via;

namespace RE4ModdingAPI;

public class EntryPoint
{
    private static ModLoader? modLoader;
    
    [PluginEntryPoint]
    public static void Entry() // Entry point
    {
        API.LogToConsole = true;
        API.LogInfo("Plugin Loaded!");
        
        OnStart();
    }

    [Callback(typeof(UpdateBehavior), CallbackType.Post)]
    private static void UpdateCallback()
    {
        OnUpdate(Application.DeltaTime);
    }

    [PluginExitPoint]
    public static void Exit() // Exit point
    {
        API.LogInfo("Plugin UnLoaded!");
        OnDisabled();
    }

    public static void OnStart()
    {
        API.LogInfo("start called!");
        modLoader = new();
        modLoader.LoadPlugins();
    }

    public static void OnUpdate(float deltaTime)
    {
        try
        {
            foreach (var plugin in modLoader.LoadedPlugins)
            {
                plugin.OnUpdate(deltaTime);
            }
        }
        catch (Exception ex)
        {
            API.LogError($"An exception has occured while calling OnUpdate for plugins with the error: {ex}");
        }
    }

    public static void OnDisabled()
    {
        foreach (var plugin in modLoader.LoadedPlugins)
        {
            plugin.OnDisabled();
        }

        modLoader.UnloadPlugins();
        API.LogInfo("disabled called!");
    }
}
