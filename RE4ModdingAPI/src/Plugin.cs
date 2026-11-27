namespace RE4ModdingAPI;

public class Plugin
{
    public virtual string? Name {get; set;} = "NotSet";
    public virtual string? Author {get; set;} = "NotSet";
    public virtual Version? Version {get; set;} = new(0,0,0);

    public virtual void OnEnabled() {}
    public virtual void OnUpdate(float deltaTime) {}  
    public virtual void OnImGuiDraw() {}
    public virtual void OnDisabled() {}
}