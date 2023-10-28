using System;

public class Quaternion
{
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;
        return new Quaternion(w, x, y, z);
    }

    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }

    public Quaternion Inverse()
    {
        var conjugate = Conjugate();
        var norm = Norm() * Norm();
        return new Quaternion(conjugate.W / norm, conjugate.X / norm, conjugate.Y / norm, conjugate.Z / norm);
    }

    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }

    public Matrix4x4 ToRotationMatrix()
    {
        double xx = X * X;
        double xy = X * Y;
        double xz = X * Z;
        double xw = X * W;
        double yy = Y * Y;
        double yz = Y * Z;
        double yw = Y * W;
        double zz = Z * Z;
        double zw = Z * W;

        return new Matrix4x4(
            1 - 2 * (yy + zz), 2 * (xy - zw), 2 * (xz + yw), 0,
            2 * (xy + zw), 1 - 2 * (xx + zz), 2 * (yz - xw), 0,
            2 * (xz - yw), 2 * (yz + xw), 1 - 2 * (xx + yy), 0,
            0, 0, 0, 1
        );
    }
}

public struct Matrix4x4
{
    public double M11, M12, M13, M14;
    public double M21, M22, M23, M24;
    public double M31, M32, M33, M34;
    public double M41, M42, M43, M44;

    public Matrix4x4(
        double m11, double m12, double m13, double m14,
        double m21, double m22, double m23, double m24,
        double m31, double m32, double m33, double m34,
        double m41, double m42, double m43, double m44)
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M14 = m14;
        M21 = m21;
        M22 = m22;
        M23 = m23;
        M24 = m24;
        M31 = m31;
        M32 = m32;
        M33 = m33;
        M34 = m34;
        M41 = m41;
        M42 = m42;
        M43 = m43;
        M44 = m44;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(2, 3, 4, 5);

        Quaternion addResult = q1 + q2;
        Quaternion subResult = q1 - q2;
        Quaternion mulResult = q1 * q2;

        Console.WriteLine($"Addition: W={addResult.W}, X={addResult.X}, Y={addResult.Y}, Z={addResult.Z}");
        Console.WriteLine($"Subtraction: W={subResult.W}, X={subResult.X}, Y={subResult.Y}, Z={subResult.Z}");
        Console.WriteLine($"Multiplication: W={mulResult.W}, X={mulResult.X}, Y={mulResult.Y}, Z={mulResult.Z}");

        double normQ1 = q1.Norm();
        Quaternion conjugateQ1 = q1.Conjugate();
        Quaternion inverseQ1 = q1.Inverse();

        Console.WriteLine($"Norm of q1: {normQ1}");
        Console.WriteLine($"Conjugate of q1: W={conjugateQ1.W}, X={conjugateQ1.X}, Y={conjugateQ1.Y}, Z={conjugateQ1.Z}");
        Console.WriteLine($"Inverse of q1: W={inverseQ1.W}, X={inverseQ1.X}, Y={inverseQ1.Y}, Z={inverseQ1.Z}");

        Matrix4x4 rotationMatrix = q1.ToRotationMatrix();
        Console.WriteLine("Rotation Matrix:");
        Console.WriteLine($"{rotationMatrix.M11}, {rotationMatrix.M12}, {rotationMatrix.M13}, {rotationMatrix.M14}");
        Console.WriteLine($"{rotationMatrix.M21}, {rotationMatrix.M22}, {rotationMatrix.M23}, {rotationMatrix.M24}");
        Console.WriteLine($"{rotationMatrix.M31}, {rotationMatrix.M32}, {rotationMatrix.M33}, {rotationMatrix.M34}");
        Console.WriteLine($"{rotationMatrix.M41}, {rotationMatrix.M42}, {rotationMatrix.M43}, {rotationMatrix.M44}");
    }
}

