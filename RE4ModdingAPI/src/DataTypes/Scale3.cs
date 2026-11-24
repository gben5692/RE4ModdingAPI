namespace RE4ModdingAPI.DataTypes;

public struct Scale3(float x, float y, float z)
{
    public float X {get; set;} = x;
    public float Y {get; set;} = y;
    public float Z {get; set;} = z;

    public static Scale3 Identity = new(0,0,0);

    public static Scale3 operator +(Scale3 a, Scale3 b) {return new Scale3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);}
    public static Scale3 operator -(Scale3 a, Scale3 b) {return new Scale3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);}
    public static Scale3 operator *(Scale3 a, Scale3 b) {return new Scale3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);}
    public static Scale3 operator /(Scale3 a, Scale3 b) {return new Scale3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);}

    public static Scale3 operator +(Scale3 a, float b) {return new Scale3(a.X + b, a.Y + b, a.Z + b);}
    public static Scale3 operator -(Scale3 a, float b) {return new Scale3(a.X - b, a.Y - b, a.Z - b);}
    public static Scale3 operator *(Scale3 a, float b) {return new Scale3(a.X * b, a.Y * b, a.Z * b);}
    public static Scale3 operator /(Scale3 a, float b) {return new Scale3(a.X / b, a.Y / b, a.Z / b);}
}