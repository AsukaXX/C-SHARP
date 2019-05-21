using System;
using static System.Math;

public class Vector
{
    public double? R = null;
    public double? Theta = null;
    public double? ThetaRadians
    {
        get { return (Theta * Math.PI / 180.0); }
    }
    public Vector(double? r, double? theta)
    {
        if (r < 0)
        {
            r = -r;
            theta += 180;
        }
        theta = theta % 360;
        R = r;
        Theta = theta;
    }
    public static Vector operator +(Vector op1, Vector op2)
    {
        try
        {
            double newX = op1.R.Value * Sin(op1.ThetaRadians.Value)
            + op2.R.Value * Sin(op2.ThetaRadians.Value);
            double newY = op1.R.Value * Cos(op1.ThetaRadians.Value)
            + op2.R.Value * Cos(op2.ThetaRadians.Value);
            double newR = Sqrt(newX * newX + newY * newY);
            double newTheta = Atan2(newX, newY) * 180.0 / PI;
            return new Vector(newR, newTheta);
        }
        catch
        {
            return new Vector(null, null);
        }
    }
    public static Vector operator -(Vector op1) => new Vector(-op1.R, op1.Theta);
    public static Vector operator -(Vector op1, Vector op2) => op1 + (-op2);
    public override string ToString()
    {
        string rstring = R.HasValue ? R.ToString() : "null";
        string thetastring = Theta.HasValue ? Theta.ToString() : "null";
        return string.Format($"({rstring}, {thetastring})");
    }
}