using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class ExtensionMethods
    {
        public static bool ApproximatelyEquals(this decimal v1, decimal v2, 
            decimal precision = 0.0000000001M)
        {
            return (Math.Abs(v1 - v2) < precision);
        }

        public static int Constrain(this int value, int min, int max)
        {
            if (value > max)
            {
                return max;
            }
            else if (value < min)
            {
                return min;
            }
            else
            {
                return value;
            }
        }

        public static string ToSymbol(this AngleUnits units)
        {
            switch (units)
            {
                case AngleUnits.Degrees:
                    return "º";
                case AngleUnits.Gradians:
                    return "g";
                case AngleUnits.Radians:
                    return "rad";
                case AngleUnits.Turns:
                    return "tr";
                default:
                    return string.Empty;
            }
        }
    }
}
