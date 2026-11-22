using RE4ModdingAPI.DataTypes;

namespace RE4ModdingAPI.GameObject;

public class Transform(via.Transform nativeTransform)
{
    private readonly via.Transform _nativeTransform = nativeTransform;
    
    public Vector3 LocalPosition 
    {
        get => _nativeTransform.LocalPosition.ToVector3();
        set
        {
            _nativeTransform.LocalPosition = value.ToNativeVector3();
        }
    }

    public Quaternion3 LocalRotation
    {
        get => _nativeTransform.LocalRotation.ToQuaternion3();
        set
        {
            _nativeTransform.LocalRotation = value.ToNativeQuaternion();
        }
    }

    public Scale3 LocalScale
    {
        get => _nativeTransform.LocalScale.ToScale3(); 
        set
        {
            _nativeTransform.LocalScale = value.ToNativeScale();
        }       
    }

    public Vector3 Position 
    {
        get => _nativeTransform.Position.ToVector3();
        set
        {
            _nativeTransform.Position = value.ToNativeVector3();
        }
    }

    public Quaternion3 Rotation
    {
        get => _nativeTransform.Rotation.ToQuaternion3();
        set
        {
            _nativeTransform.Rotation = value.ToNativeQuaternion();
        }
    }

    public Scale3 Scale
    {
        get => _nativeTransform.Scale.ToScale3(); 
    }
}