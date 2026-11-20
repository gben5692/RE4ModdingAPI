namespace RE4ModdingAPI.DataTypes;

public struct Quaternion3(float x, float y, float z, float w)
{
    private const float Deg2Rad = MathF.PI / 180f;
    private const float Rad2Deg = 180f / MathF.PI;

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

    public Vector3 ToEuler()
    {
         // Pitch (X-axis rotation)
        float sinP = 2f * (W * X - Y * Z);
        float pitch = MathF.Abs(sinP) >= 1f
            ? MathF.CopySign(MathF.PI / 2f, sinP) // Gimbal lock clamp
            : MathF.Asin(sinP);

        // Yaw (Y-axis rotation)
        float sinY = 2f * (W * Y + X * Z);
        float cosY = 1f - 2f * (X * X + Y * Y);
        float yaw = MathF.Atan2(sinY, cosY);

        // Roll (Z-axis rotation)
        float sinR = 2f * (W * Z + X * Y);
        float cosR = 1f - 2f * (X * X + Z * Z);
        float roll = MathF.Atan2(sinR, cosR);

        return new Vector3(pitch * Rad2Deg, yaw * Rad2Deg, roll * Rad2Deg);
    }

    public static Quaternion3 FromEuler(Vector3 rotation)
    {
        // Convert degrees to half-angles in radians (YXZ / Yaw-Pitch-Roll order)
        float halfPitch = rotation.X * Deg2Rad * 0.5f;
        float halfYaw = rotation.Y * Deg2Rad * 0.5f;
        float halfRoll = rotation.Z * Deg2Rad * 0.5f;

        float sp = MathF.Sin(halfPitch);
        float cp = MathF.Cos(halfPitch);
        float sy = MathF.Sin(halfYaw);
        float cy = MathF.Cos(halfYaw);
        float sr = MathF.Sin(halfRoll);
        float cr = MathF.Cos(halfRoll);

        return new Quaternion3
        (
            cy * sp * cr + sy * cp * sr,
            sy * cp * cr - cy * sp * sr,
            cy * cp * sr - sy * sp * cr,
            cy * cp * cr + sy * sp * sr
        );
    }
}