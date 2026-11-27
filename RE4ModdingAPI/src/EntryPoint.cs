using RE4ModdingAPI.Loader;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;
using via;

namespace RE4ModdingAPI;

internal class EntryPoint
{
    private static ModLoader? modLoader;
    
    [PluginEntryPoint]
    public static void Entry() // Entry point
    {
        API.LogToConsole = true;
        API.LogInfo("[API] Plugin Loaded!");
        
        OnStart();
    }

    [Callback(typeof(UpdateBehavior), CallbackType.Post)]
    private static void UpdateCallback()
    {
        OnUpdate(Application.DeltaTime);
    }

    [Callback(typeof(ImGuiDrawUI), CallbackType.Post)]
    private static void ImGuiDrawCallback()
    {
        OnImGuiDraw();
    }

    [PluginExitPoint]
    public static void Exit() // Exit point
    {
        API.LogInfo("[API] Plugin UnLoaded!");
        OnDisabled();
    }

    public static void OnStart()
    {
        API.LogInfo("[API] Start Called!");
        modLoader = new();
        modLoader.LoadPlugins();
    }

    public static void OnUpdate(float deltaTime)
    {
        try
        {
            foreach (var plugin in modLoader!.LoadedPlugins!)
            {
                plugin.OnUpdate(deltaTime);
            }
        }
        catch (Exception ex)
        {
            API.LogError($"[API] An exception has occured while calling OnUpdate for plugins with the error: {ex}");
        }
    }

    public static void OnImGuiDraw()
    {
        try
        {
            foreach (var plugin in modLoader!.LoadedPlugins!)
            {
                plugin.OnImGuiDraw();
            }
        }
        catch (Exception ex)
        {
            API.LogError($"[API] An exception has occured while calling OnImGuiDraw for plugins with the error: {ex}");
        }
    }

    public static void OnDisabled()
    {
        try
        {
            foreach (var plugin in modLoader!.LoadedPlugins!)
            {
                plugin.OnDisabled();
            }
        }
        catch (Exception ex)
        {
            API.LogError($"[API] Error in trying to call OnDisabled with the error: {ex}");
        }
        

        modLoader!.UnloadPlugins();
        API.LogInfo("[API] Disabled called!");
    }
}
