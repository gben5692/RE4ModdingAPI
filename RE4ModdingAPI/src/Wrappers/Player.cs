using chainsaw;
using RE4ModdingAPI.DataTypes;
using RE4ModdingAPI.Delegates;
using RE4ModdingAPI.Events.Player;
using RE4ModdingAPI.GameObject;
using via.physics;

namespace RE4ModdingAPI.Wrappers;

public static class Player
{
#region Internal References
    private static CharacterContext PlayerRefs => Singleton.CharacterManager.getPlayerContextRef();
#endregion

#region Events

    public static event RE4Event<HealthChangedEvent> HealthChanged;

#endregion

#region  Components

    /// <summary>
    /// The transform component
    /// </summary>
    public static Transform Transform => new(PlayerRefs.BodyGameObject.Transform);

    /// <summary>
    /// The character controller component
    /// </summary>
    public static CharacterController CharacterController => PlayerRefs.BodyUpdater.CharacterController;

#endregion

#region Properties

    public static Inventory Inventory {get;} = new();

    /// <summary>
    /// The max health of the player
    /// </summary>
    public static int MaxHealth
    {
        get => PlayerRefs.HitPoint.DefaultHitPoint;
        set => PlayerRefs.HitPoint.DefaultHitPoint = value;
    }

    /// <summary>
    /// The health in percentage
    /// </summary>
    public static float HealthPercentage => (float)Health / MaxHealth;

    /// <summary>
    /// This is current health of the player
    /// </summary>
    public static int Health 
    {
        get => PlayerRefs.HitPoint.CurrentHitPoint;
        set => PlayerRefs.HitPoint.CurrentHitPoint = value;
    }

    /// <summary>
    /// If the player is immortal (Takes damage until 1 hp)
    /// </summary>
    public static bool IsImmortal
    {
        get => PlayerRefs.HitPoint.Immortal;
        set => PlayerRefs.HitPoint.Immortal = value;
    }

    /// <summary>
    /// If the player is invincible (Player wont take damage)
    /// </summary>
    public static bool IsInvincible
    {
        get => PlayerRefs.HitPoint.Invincible;
        set => PlayerRefs.HitPoint.Invincible = value;
    }

    /// <summary>
    /// If the player is dead
    /// </summary>
    public static bool IsDead => PlayerRefs.HitPoint.IsDead;

    /// <summary>
    /// If the player is changing costume
    /// </summary>
    public static bool IsCostumeChanging => PlayerRefs.IsCostumeChanging;

    /// <summary>
    /// If the player is eliminated
    /// </summary>
    public static bool IsEliminated => PlayerRefs.IsEliminated;

    /// <summary>
    /// The player movement speed
    /// </summary>
    public static float MoveSpeed 
    {
        get => PlayerRefs.MoveIntensity;
        set => PlayerRefs.MoveIntensity = value;
    }

    /// <summary>
    /// The look speed (Head)
    /// </summary>
    public static float LookSpeed
    {
        get => PlayerRefs.WatchIntensity;
        set => PlayerRefs.WatchIntensity = value;
    }

    /// <summary>
    /// If the player is in a animation (Grabbing)
    /// </summary>
    public static bool IsTargetJacked => PlayerRefs.TargetJacked;

#endregion

#region Methods

    /// <summary>
    /// This function teleports the player
    /// </summary>
    /// <param name="position">The position to teleport</param>
    /// <param name="rotation">The rotation</param>
    public static void Teleport(Vector3 position, Quaternion3 rotation)
    {
        Transform.Position = position;
        Transform.Rotation = rotation;

        CharacterController.warp();
    }

#endregion

#region EventMethods
    // not finished

    private static int previousHealth = 0;
    public static void HealthChangedMethodHandler()
    {
        if (previousHealth != PlayerRefs.HitPoint.CurrentHitPoint)
        {
            previousHealth = PlayerRefs.HitPoint.CurrentHitPoint;
        }

        if (PlayerRefs.HitPoint.IsHPChanged)
        {
            HealthChanged?.Invoke(new(previousHealth, PlayerRefs.HitPoint.CurrentHitPoint));
        }

        previousHealth = PlayerRefs.HitPoint.CurrentHitPoint;
    }

#endregion
}