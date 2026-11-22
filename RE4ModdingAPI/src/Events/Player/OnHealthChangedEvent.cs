namespace RE4ModdingAPI.Events.Player;

public readonly record struct HealthChangedEvent(int PreviousHealth, int CurrentHealth)
{

}
