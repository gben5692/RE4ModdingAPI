using chainsaw;
using RE4ModdingAPI.Delegates;
using RE4ModdingAPI.Events.Player;
using RE4ModdingAPI.GameObject;

namespace RE4ModdingAPI.Wrappers;

public static class Player
{
    private static CharacterContext PlayerRefs => Singleton.CharacterManager.getPlayerContextRef();

    public static event RE4Event<OnHealthChangedEvent>? HealthChanged;

    public static Transform Transform
    {
        get
        {
            if (PlayerRefs == null)
                return null;

            return new(PlayerRefs.BodyGameObject.Transform);
        }
    }

    public static int Health 
    {
        get
        {
            if (PlayerRefs == null)
                return 0;

            return PlayerRefs.HitPoint.CurrentHitPoint;
        }
        set
        {
            if (PlayerRefs == null)
                return;

            PlayerRefs.HitPoint.CurrentHitPoint = value;
        }
    }

    public static bool IsInvincible
    {
        get
        {
            if (PlayerRefs == null)
                return false;

            return PlayerRefs.HitPoint.Invincible;
        }
        set
        {
            if (PlayerRefs == null)
                return;

            PlayerRefs.HitPoint.Invincible = value;
        }
    }

    public static bool IsDead
    {
        get
        {
            if (PlayerRefs == null)
                return false;

            return PlayerRefs.HitPoint.IsDead;
        }
    }
    
    // public static bool IsJumping
    // {
    //     get
    //     {
    //         if (PlayerRefs == null)
    //             return false;
            
    //     }
    // }
}