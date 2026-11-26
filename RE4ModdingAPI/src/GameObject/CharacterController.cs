using RE4ModdingAPI.DataTypes;

namespace RE4ModdingAPI.GameObject;

public class CharacterController(via.physics.CharacterController characterController)
{
    /// <summary>
    /// If the character is on the ground
    /// </summary>
    public bool IsGrounded
    {
        get
        {
            if (characterController == null)
            return false;

            return characterController.Ground;
        }
    }

    public Vector3 GravityDirection
    {
        get
        {
            if (characterController == null)
            return Vector3.Identity;

            return characterController.GravityDirection.ToVector3();
        }
        set
        {
            if (characterController == null)
            return;

            characterController.GravityDirection = value.ToNativeVector3();
        }
    }

    public bool Jump
    {
        get
        {
            if (characterController == null)
            return false;

            return characterController.Jump;
        }
        set
        {
            if (characterController == null)
            return;

            characterController.Jump = value;
        }
    }

    public float SlopeLimit
    {
        get
        {
            if (characterController == null)
            return 0f;

            return characterController.SlopeLimit;
        }
        set
        {
            if (characterController == null)
            return;

            characterController.SlopeLimit = value;
        }
    }


    public void Warp()
    {
        if (characterController == null)
        return;

        characterController.warp();
    }
}