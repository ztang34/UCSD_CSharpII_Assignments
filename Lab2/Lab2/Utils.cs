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
            double minX = points.Min(point => point.X);
            double maxX = points.Max(point => point.X);
            double minY = points.Min(point => point.Y);
            double maxY = points.Max(point => point.Y);

            return new Tuple<double, double, double, double>(minX, minY, maxX, maxY);
        }
    }
}
