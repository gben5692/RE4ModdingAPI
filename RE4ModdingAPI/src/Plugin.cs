namespace RE4ModdingAPI;

public class Plugin
{
    public virtual string? Name {get; set;}
    public virtual string? Author {get; set;}
    public virtual Version? Version {get; set;}

    public virtual void OnEnabled() {}
    public virtual void OnUpdate() {}  
    public virtual void OnDisabled() {}
}