using RE4ModdingAPI;
using RE4ModdingAPI.Wrappers;

namespace Examples;

public class GroundIsLava : Plugin
{
    public override string? Name { get; set; } = "GroundIsLava"; // the name of the plugin
    public override string? Author { get; set; } = "gben5692"; // the author who made the plugin
    public override Version? Version { get; set; } = new(0,0,1); // the version of the plugin

    public override void OnEnabled() // this runs once when it is loaded 
    {
    }

    public override void OnUpdate(float deltaTime) // this runs every frame
    {
        if (Player.CharacterController!.Ground)
        {
            Player.Health -= 1;
        }
    }

    public override void OnDisabled() // this runs once the API is being disabled
    {
    }
}
