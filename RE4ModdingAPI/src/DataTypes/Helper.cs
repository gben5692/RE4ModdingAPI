using via;
using ValueType = REFrameworkNET.ValueType;

namespace RE4ModdingAPI.DataTypes;

public static class Helper
{
    public static Vector3 ToVector3(this vec3 position) {return new Vector3(position.x, position.y, position.z);}
    public static Quaternion3 ToQuaternion3(this Quaternion rotation) {return new Quaternion3(rotation.x, rotation.y, rotation.z, rotation.w);}
    public static Scale3 ToScale3(this vec3 scale) {return new Scale3(scale.x, scale.y, scale.z);}
    public static vec3 ToNativeVector3(this Vector3 position) 
    {
        var nativePosition = ValueType.New<vec3>(); 

        nativePosition.x = position.X; 
        nativePosition.y = position.Y; 
        nativePosition.z = position.Z; 

        return nativePosition; 
    }

    public static Quaternion ToNativeQuaternion(this Quaternion3 rotation)
    {
        var nativeQuaternion = ValueType.New<Quaternion>();

        nativeQuaternion.x = rotation.X;
        nativeQuaternion.y = rotation.Y;
        nativeQuaternion.z = rotation.Z;
        nativeQuaternion.w = rotation.W;

        return nativeQuaternion;
    }

    public static vec3 ToNativeScale(this Scale3 scale)
    {
        var nativeScale = ValueType.New<vec3>(); 

        nativeScale.x = scale.X; 
        nativeScale.y = scale.Y; 
        nativeScale.z = scale.Z; 

        return nativeScale; 
    }
}