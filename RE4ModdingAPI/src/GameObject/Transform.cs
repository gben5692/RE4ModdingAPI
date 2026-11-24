using RE4ModdingAPI.DataTypes;
using ValueType = REFrameworkNET.ValueType;

namespace RE4ModdingAPI.GameObject;

public class Transform(via.Transform nativeTransform)
{
    private readonly via.Transform _nativeTransform = nativeTransform;
    
    public Vector3 LocalPosition 
    {
        get
        {
            if (_nativeTransform == null || _nativeTransform.LocalPosition == null)
            return Vector3.Identity;

            return _nativeTransform.LocalPosition.ToVector3();
        }
        set
        {
            if (_nativeTransform == null || _nativeTransform.LocalPosition == null)
            return;

            _nativeTransform.LocalPosition = value.ToNativeVector3();
        }
    }

    public Quaternion3 LocalRotation
    {
        get
        {
            if (_nativeTransform == null || _nativeTransform.LocalRotation == null)
            return Quaternion3.Identity;

            return _nativeTransform.LocalRotation.ToQuaternion3();
        } 
        set
        {
            if (_nativeTransform == null || _nativeTransform.LocalRotation == null)
            return;

            _nativeTransform.LocalRotation = value.ToNativeQuaternion();
        }
    }

    public Scale3 LocalScale
    {
        get
        {
            if (_nativeTransform == null || _nativeTransform.LocalScale == null)
            return Scale3.Identity;

            return  _nativeTransform.LocalScale.ToScale3();
        }  
        set
        {
            if (_nativeTransform == null || _nativeTransform.LocalScale == null)
            return;

            _nativeTransform.LocalScale = value.ToNativeScale();
        }       
    }

    public Vector3 Position 
    {
        get
        {
            if (_nativeTransform == null || _nativeTransform.Position == null)
            return Vector3.Identity;

            return _nativeTransform.Position.ToVector3();
        } 
        set
        {
            if (_nativeTransform == null || _nativeTransform.Position == null)
            return;

            _nativeTransform.Position = value.ToNativeVector3();
        }
    }

    public Quaternion3 Rotation
    {
        get
        {
            if (_nativeTransform == null || _nativeTransform.Rotation == null)
            return Quaternion3.Identity;

            return _nativeTransform.Rotation.ToQuaternion3();
        }
        set
        {
            if (_nativeTransform == null || _nativeTransform.Rotation == null)
            return;

            _nativeTransform.Rotation = value.ToNativeQuaternion();
        }
    }

    public Scale3 Scale
    {
        get
        {
            if (_nativeTransform == null || _nativeTransform.Scale == null)
            return Scale3.Identity;

            return _nativeTransform.Scale.ToScale3();
        }
    }

    public static Transform Identity()
    {
        var nativeTransform = ValueType.New<via.Transform>();

        nativeTransform.Position = Vector3.Identity.ToNativeVector3();
        nativeTransform.Rotation = Quaternion3.Identity.ToNativeQuaternion();

        nativeTransform.LocalPosition = Vector3.Identity.ToNativeVector3();
        nativeTransform.LocalRotation = Quaternion3.Identity.ToNativeQuaternion();
        nativeTransform.LocalScale = Scale3.Identity.ToNativeScale();

        return new Transform(nativeTransform);
    }
}