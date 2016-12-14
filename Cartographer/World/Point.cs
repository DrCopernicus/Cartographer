using System;

namespace Cartographer.World
{
    public class Point
    {
        public double X;
        public double Y;
        public double Z;

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point Between(Point other)
        {
            return new Point(
                (X + other.X)/2,
                (Y + other.Y)/2,
                (Z + other.Z)/2);
        }

        public Point PushFrom(Point other, double distance)
        {
            var x = X;
            var y = Y;
            var z = Z;

            var phi = Math.Atan2(y, x);
            var theta = Math.Acos(z / Math.Sqrt(X*X+Y*Y+Z*Z));

            var point = new Point(
                distance*Math.Sin(theta)*Math.Cos(phi),
                distance*Math.Sin(theta)*Math.Sin(phi),
                distance*Math.Cos(theta));

            return point;
        }

        public double GetLongitude(Point center)
        {
            return Math.Atan2(Y, X);
        }

        public double GetLatitude(Point center)
        {
            return Math.Atan2(Z, Math.Sqrt(X * X + Y * Y));
        }

        public static Point Zero()
        {
            return new Point(0, 0, 0);
        }

        public override string ToString()
        {
            return string.Format("{0:0.000},{1:0.000}", X*100+157, Y*100+157);
        }
    }
}
