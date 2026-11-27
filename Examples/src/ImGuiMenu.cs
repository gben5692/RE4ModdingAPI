using RE4ModdingAPI;
using Hexa.NET.ImGui;
using RE4ModdingAPI.Wrappers;

namespace Examples;

public class ImGuiMenu : Plugin
{
    public override string? Name { get; set; } = "Test";
    public override string? Author { get; set; } = "gben5692";
    public override Version? Version { get; set; } = new(0,0,1);

    public override void OnImGuiDraw() // To actually show a window on the screen with imgui. install Hexa.NET.ImGui
    {
        if (ImGui.Begin("Test Window"))
        {
            if (ImGui.Button("Heal?"))
            {
                Player.Health += 25;
            }

            if (ImGui.Button("Become Tiny?"))
            {
                Player.Transform.LocalScale = new(0.5f, 0.5f, 0.5f);
            }

            if (ImGui.Button("Become Big?"))
            {
                Player.Transform.LocalScale = new(2f, 2f, 2f);
            }

            if (ImGui.Button("Become Normal?"))
            {
                Player.Transform.LocalScale = new(1f, 1f, 1f);
            }
        }

        ImGui.End();
    }
}
