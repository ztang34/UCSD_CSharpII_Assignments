using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Utils
    {
        public static bool IsRelativelyEqual (double d1, double d2)
        {
            double margin = Math.Abs((d1 + d2) * 0.0001 / 2);
            double diff = Math.Abs(d1 - d2);

            if (diff < margin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Tuple<double, double, double, double> GetBoundingBox(List<Point> points)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            foreach (Point pt in points)
            {
                x.Add(pt.X);
                y.Add(pt.Y);
            }
            double minX = x.Min();
            double maxX = x.Max();
            double minY = y.Min();
            double maxY = y.Max();

            return new Tuple<double, double, double, double>(minX, minY, maxX, maxY);
        }
    }
}
