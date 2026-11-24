namespace RE4ModdingAPI.DataTypes;

public struct Vector3(float x, float y, float z)
{
    public float X {get; set;} = x;
    public float Y {get; set;} = y;
    public float Z {get; set;} = z;

    public static Vector3 Identity = new(0,0,0);

    public static Vector3 operator +(Vector3 a, Vector3 b) {return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);}
    public static Vector3 operator -(Vector3 a, Vector3 b) {return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);}
    public static Vector3 operator *(Vector3 a, Vector3 b) {return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);}
    public static Vector3 operator /(Vector3 a, Vector3 b) {return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);}

    public static Vector3 operator +(Vector3 a, float b) {return new Vector3(a.X + b, a.Y + b, a.Z + b);}
    public static Vector3 operator -(Vector3 a, float b) {return new Vector3(a.X - b, a.Y - b, a.Z - b);}
    public static Vector3 operator *(Vector3 a, float b) {return new Vector3(a.X * b, a.Y * b, a.Z * b);}
    public static Vector3 operator /(Vector3 a, float b) {return new Vector3(a.X / b, a.Y / b, a.Z / b);}
}