using RE4ModdingAPI;
using RE4ModdingAPI.Events.Player;
using RE4ModdingAPI.Wrappers;
using REFrameworkNET;

public class BigLeon : Plugin
{
    public override string? Name { get; set; } = "BigLeon"; // the name of the plugin
    public override string? Author { get; set; } = "gben5692"; // the author who made the plugin
    public override Version? Version { get; set; } = new(0,0,1); // the version of the plugin

    public override void OnEnabled() // this runs once when it is loaded 
    {
        Player.Transform.LocalScale = new(2, 2, 2);
    }

    public override void OnUpdate(float deltaTime) // this runs every frame
    {
    }

    public override void OnDisabled() // this runs once the API is being disabled
    {
        Player.Transform.LocalScale = new(1,1,1);
    }
}