using via;

namespace RE4ModdingAPI.DataTypes;

public struct Quaternion3(float x, float y, float z, float w)
{
    public float X {get; set;} = x;
    public float Y {get; set;} = y;
    public float Z {get; set;} = z;
    public float W {get; set;} = w;

    public static Quaternion3 operator *(Quaternion3 a, Quaternion3 b)
    {
        return new
        (
            a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
            a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
            a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W,
            a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z
        );
    }

    public static Quaternion3 Identity {get;} = new(0, 0, 0, 1);

    public readonly Quaternion3 Normalized()
    {
        float normalized = (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

        if (normalized == 0)
            return Identity;

        return new (X / normalized, Y / normalized, Z / normalized, W / normalized);
    }

    public readonly Vector3 ToEuler()
    {
        var rotationNormalized = Normalized();
        float toDegrees = (float)(180 / Math.PI);

        float pitchX = (float)Math.Asin(Math.Clamp(2 * (rotationNormalized.W * rotationNormalized.X - rotationNormalized.Y * rotationNormalized.Z), -1, 1));
        float yawY = (float)Math.Atan2(2 * (rotationNormalized.W * rotationNormalized.Y + rotationNormalized.X * rotationNormalized.Z), 1 - 2 * (rotationNormalized.X * rotationNormalized.X + rotationNormalized.Y * rotationNormalized.Y));
        float rollZ = (float)Math.Atan2(2 * (rotationNormalized.W * rotationNormalized.Z + rotationNormalized.X * rotationNormalized.Y), 1 - 2 * (rotationNormalized.X * rotationNormalized.X + rotationNormalized.Z * rotationNormalized.Z));

        return new Vector3(pitchX * toDegrees, yawY * toDegrees, rollZ * toDegrees);
    }

    public static Quaternion3 FromEuler(Vector3 rotation)
    {
        float toHalfRadians = (float)(Math.PI / 360);

        float halfX = rotation.X * toHalfRadians;
        float halfY = rotation.Y * toHalfRadians;
        float halfZ = rotation.Z * toHalfRadians;

        Quaternion3 rotationX = new((float)Math.Sin(halfX), 0, 0, (float)Math.Cos(halfX));
        Quaternion3 rotationY = new(0, (float)Math.Sin(halfY), 0, (float)Math.Cos(halfY));
        Quaternion3 rotationZ = new(0, 0, (float)Math.Sin(halfZ), (float)Math.Cos(halfZ));

        return rotationX * rotationY * rotationZ;
    }
}