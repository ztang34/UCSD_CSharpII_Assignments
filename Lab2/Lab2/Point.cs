using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public struct Point
    {
        public double X, Y;

        public Point (double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distance (Point other)
        {
            return Math.Sqrt(Math.Pow((this.X - other.X), 2) + Math.Pow((this.Y - other.Y), 2)); //Calculate distance between two points in Cartessian Coordinates
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
