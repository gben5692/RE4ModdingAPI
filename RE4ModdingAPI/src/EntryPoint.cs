using RE4ModdingAPI.DataTypes;
using RE4ModdingAPI.Loader;
using RE4ModdingAPI.Wrappers;
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

    [Callback(typeof(UpdateBehavior), CallbackType.Pre)]
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
    }

    public static void OnUpdate(float deltaTime)
    {
        API.LogInfo("update called!");
        Player.Transform.Rotation *= Quaternion3.FromEuler(new(1,1,1)) ;
    }

    public static void OnDisabled()
    {
        API.LogInfo("disabled called!");
    }
}
