using System;

namespace EASYTools.ImageEffectLibrary
{
    public static class Utils
    {
        public static int Round(this double n) => (int) Math.Round(n);

        public static float LimitTo(this float n, float min, float max) => n < min ? min : n > max ? max : n;

        public static int LimitTo(this int n, int min, int max) => n < min ? min : n > max ? max : n;
        
        public static double LimitTo(this double n, double min, double max) => n < min ? min : n > max ? max : n;
        
        public static byte LimitTo(this byte n, byte min, byte max) => n < min ? min : n > max ? max : n;

        public static double Squared(this double n) => n * n;

        public static float Squared(this float n) => n * n;

        public static double Squared(this int n) => n * n;

        public static double Rearrange(this double n, double originMin, double originMax, double min, double max) =>
            (max - originMax) / (min - originMin) * (n - originMin) + originMax;
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point Zeros { get; } = new Point(0, 0);

        public Point(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator -(Point p) => new Point(-p.X, -p.Y);

        public int GetSquaredDistance(Point point)
        {
            return (X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y);
        }

        public Point RotateR(Point origin, double angle)
        {
            return new Point(
                (int) Math.Round(origin.X + (X - origin.X) * Math.Cos(angle) - (Y - origin.Y) * Math.Sin(angle)),
                (int) Math.Round(origin.Y + (X - origin.X) * Math.Sin(angle) + (Y - origin.Y) * Math.Cos(angle))
            );
        }

        public Point RotateD(Point origin, double angle)
        {
            return RotateR(origin, angle / 180 * Math.PI);
        }
    }

    public struct Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Line(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Line(Point p1, Point p2) : this(p2.Y - p1.Y, p1.X - p2.X, p2.X * p1.Y - p1.X * p2.Y)
        {
        }

        public Line(double h, Axis axis) : this(0, 0, -h)
        {
            switch (axis)
            {
                case Axis.X:
                    A = 1;
                    break;
                case Axis.Y:
                    B = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }
        }

        public enum Axis
        {
            X,
            Y
        }

        public static Point? Intersection(Line l1, Line l2)
        {
            var m = l1.A * l2.B - l2.A * l1.B;
            if (Math.Abs(m) <= double.Epsilon) return null;
            var x = (l2.C * l1.B - l1.C * l2.B) / m;
            var y = (l1.C * l2.A - l2.C * l1.A) / m;
            return new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        }
    }
}