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
    private static PlayerManager PlayerManager => Singleton.PlayerManager;
#endregion

#region Events

    // public static event RE4Event<HealthChangedEvent> HealthChanged;

#endregion

#region  Components

    /// <summary>
    /// The transform component
    /// </summary>
    public static Transform Transform
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.BodyGameObject == null || PlayerRefs.BodyGameObject.Transform == null)
            return Transform.Identity();

            return new Transform(PlayerRefs.BodyGameObject.Transform);
        }
    }

    /// <summary>
    /// The character controller component
    /// </summary>
    public static GameObject.CharacterController CharacterController
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.BodyUpdater == null || PlayerRefs.BodyUpdater.CharacterController == null)
            return null;

            return new(PlayerRefs.BodyUpdater.CharacterController);
        }
    }

#endregion

#region Properties

    public static Inventory Inventory {get;} = new();

    /// <summary>
    /// The max health of the player
    /// </summary>
    public static int MaxHealth
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return 0;

            return PlayerRefs.HitPoint.DefaultHitPoint;
        }
        set
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return;

            PlayerRefs.HitPoint.DefaultHitPoint = value;
        }
    }

    /// <summary>
    /// This is current health of the player
    /// </summary>
    public static int Health 
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return 0;

            return PlayerRefs.HitPoint.CurrentHitPoint;
        }
        set
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return;

            PlayerRefs.HitPoint.CurrentHitPoint = value;
        }
    }

    /// <summary>
    /// If the player is immortal (Takes damage until 1 hp)
    /// </summary>
    public static bool IsImmortal
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return false;

            return PlayerRefs.HitPoint.Immortal;
        }
        set
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return;

            PlayerRefs.HitPoint.Immortal = value;
        }
    }

    /// <summary>
    /// If the player is invincible (Player wont take damage)
    /// </summary>
    public static bool IsInvincible
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return false;

            return PlayerRefs.HitPoint.Invincible;
        }
        set
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return;

            PlayerRefs.HitPoint.Invincible = value;
        }
    }

    /// <summary>
    /// If the player is dead
    /// </summary>
    public static bool IsDead
    {
        get
        {
            if (PlayerRefs == null || PlayerRefs.HitPoint == null)
            return false;

            return PlayerRefs.HitPoint.IsDead;
        }
    }

    /// <summary>
    /// If the player is changing costume
    /// </summary>
    public static bool IsCostumeChanging
    {
        get
        {
            if (PlayerRefs == null)
            return false;

            return PlayerRefs.IsCostumeChanging;
        }
    }

    /// <summary>
    /// If the player is eliminated
    /// </summary>
    public static bool IsEliminated
    {
        get
        {
            if (PlayerRefs == null)
            return false;

            return PlayerRefs.IsEliminated;
        }
    }

    /// <summary>
    /// The player movement speed
    /// </summary>
    public static float MoveIntensity
    {
        get
        {
            if (PlayerRefs == null)
            return 0f;
            
            return PlayerRefs.MoveIntensity;
        }
        set
        {
            if (PlayerRefs == null)
            return;

            PlayerRefs.MoveIntensity = value;
        }
    }

    /// <summary>
    /// The look speed (Head)
    /// </summary>
    public static float WatchIntensity
    {
        get
        {
            if (PlayerRefs == null)
            return 0f;
            
            return PlayerRefs.WatchIntensity;
        }
        set
        {
            if (PlayerRefs == null)
            return;

            PlayerRefs.WatchIntensity = value;
        }
    }

    /// <summary>
    /// If the player is in a animation (Grabbing)
    /// </summary>
    public static bool IsTargetJacked
    {
        get
        {
            if (PlayerRefs == null)
            return false;

            return PlayerRefs.TargetJacked;
        }
    }

#endregion

#region Methods

    /// <summary>
    /// This function teleports the player
    /// </summary>
    /// <param name="position">The position to teleport</param>
    /// <param name="rotation">The rotation</param>
    public static void Teleport(Vector3 position, Quaternion3 rotation)
    {
        if (Transform == null || CharacterController == null)
        return;

        Transform.Position = position;
        Transform.Rotation = rotation;

        CharacterController.Warp();
    }

#endregion

#region EventMethods
    // not finished

    // private static int previousHealth = 0;
    // public static void HealthChangedMethodHandler()
    // {
    //     if (previousHealth != PlayerRefs.HitPoint.CurrentHitPoint)
    //     {
    //         previousHealth = PlayerRefs.HitPoint.CurrentHitPoint;
    //     }

    //     if (PlayerRefs.HitPoint.IsHPChanged)
    //     {
    //         HealthChanged?.Invoke(new(previousHealth, PlayerRefs.HitPoint.CurrentHitPoint));
    //     }

    //     previousHealth = PlayerRefs.HitPoint.CurrentHitPoint;
    // }

#endregion
}