using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Angle: IFormattable
    {
        #region FieldsAndProperties
        public const decimal pi = 3.1415926535897932384626434M;
        public const decimal twoPi = 2M * pi;
        private decimal _Value = 0M;
        private AngleUnits _Units = AngleUnits.Degrees;
        private static decimal[,] _ConversionFactors = { { 1M, 9M / 10M, 180M / pi, 360 },{ 10M / 9M, 1M, 200M / pi, 400M },
            { pi / 180M, pi / 200M, 1, twoPi }, { 1M / 360M, 1M / 400M, 1M / twoPi, 1 }};

        public decimal Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = Normalize(value, Units);
            }
        }

        public AngleUnits Units
        {
            get
            {
                return _Units;
            }
            set
            {
                _Value = ConvertAngleValue(Value, Units, value); //convert angle to newly assigned unit
                _Units = value;
            }
        }
        #endregion FieldsAndProperties

        #region Constructor

        public Angle () : this(0)
        {
        }

        public Angle(Angle other) : this(other.Value, other.Units)
        {

        }
        public Angle(decimal value, AngleUnits units = AngleUnits.Degrees)
        {
            Units = units;
            Value = value;
        }

        #endregion Constructor

        #region HelperMethods
        private static decimal Normalize(decimal value, AngleUnits units)
        {
            switch(units)
            {
                case AngleUnits.Degrees:
                    if(value < 0 || value > 360)
                    {
                        value -= Math.Floor(value / 360) * 360;
                    }
                    return value;
                   
                case AngleUnits.Gradians:
                    if (value < 0 || value > 400)
                    {
                        value -= Math.Floor(value / 400) * 400;
                    }
                    return value;

                case AngleUnits.Radians:
                    if (value < 0 || value > twoPi)
                    {
                        value -= Math.Floor(value / twoPi) * twoPi;
                    }
                    return value;

                case AngleUnits.Turns:
                    if(value < 0 || value > 1)
                    {
                        value -= Math.Floor(value);
                    }
                    return value;
                default:
                    return 0M;
            }
        }

        private static decimal ConvertAngleValue(decimal angle, AngleUnits fromUnits, AngleUnits toUnits)

        {
            decimal factor = _ConversionFactors[(int)toUnits, (int)fromUnits];
            return Normalize((angle * factor), toUnits); //Normalize converted angle 
        }

        public Angle ToDegrees()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Degrees), AngleUnits.Degrees);
        }

        public Angle ToGradians()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Gradians), AngleUnits.Gradians);
        }

        public Angle ToRadians()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Radians), AngleUnits.Radians);
        }

        public Angle ToTurns()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Turns), AngleUnits.Turns);
        }

        public Angle ConvertAngle(AngleUnits targetUnits)
        {
            switch(targetUnits)
            {
                case AngleUnits.Degrees:
                    return ToDegrees();
                case AngleUnits.Radians:
                    return ToRadians();
                case AngleUnits.Gradians:
                    return ToGradians();
                case AngleUnits.Turns:
                    return ToTurns();
                default:
                    return this; 
            }
        }

        #endregion HelperMethods

        #region MathematicalOperatorsOverload

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle((a1.Value + Angle.ConvertAngleValue(a2.Value, a2.Units, a1.Units)), a1.Units);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle((a1.Value - Angle.ConvertAngleValue(a2.Value, a2.Units, a1.Units)), a1.Units);
        }

        public static Angle operator + (Angle a, decimal scalar)
        {
            return new Angle((a.Value + scalar), a.Units);
        }

        public static Angle operator -(Angle a, decimal scalar)
        {
            return new Angle((a.Value - scalar), a.Units);
        }

        public static Angle operator *(Angle a, decimal scalar)
        {
            return new Angle((a.Value * scalar), a.Units);
        }

        public static Angle operator /(Angle a, decimal scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Cannot divide angle by a zero value");
            }
            else
            {
                return new Angle((a.Value / scalar), a.Units);
            }
        }

        #endregion MathematicalOperatorsOverload

        #region ComparisonOperatorsOverload

        public static bool operator == (Angle a, Angle b)
        {
            object o1 = a;
            object o2 = b;

            if(o1 == null && o2 == null)
            {
                return true;
            }
            else if (o1 == null ^ o2 == null)
            {
                return false;
            }
            else
            {
                return a.Value.ApproximatelyEquals(Angle.ConvertAngleValue(b.Value, b.Units, a.Units));
            }

        }

        public static bool operator !=(Angle a, Angle b)
        {
            return !(a == b);
        }

        public static bool operator < (Angle a, Angle b)
        {
            if (a == null && b == null)
            {
                return false;
            }
            else if (a == null)
            {
                return true;
            }
            else if (b == null)
            {
                return false;
            }
            else
            {
                return a.Value < Angle.ConvertAngleValue(b.Value, b.Units, a.Units);
            }
        }

        public static bool operator > (Angle a, Angle b)
        {
            return !(a < b || a == b);
        }

        public static bool operator >= (Angle a, Angle b)
        {
            return (a > b || a == b);
        }

        public static bool operator <= (Angle a, Angle b)
        {
            return (a < b || a == b);
        }

        #endregion ComparisonOperatorsOverload

        #region ObjectOverrides

        public override bool Equals(object obj)
        {
            return (this == obj as Angle);
        }

        public override int GetHashCode()
        {
            return ConvertAngleValue(Value, Units, AngleUnits.Degrees).GetHashCode();
        }

        
        #endregion ObjectOverrides

        #region ConversionOperators

        public static explicit operator decimal(Angle a)
        {
            return a.Value;
        }

        public static explicit operator double (Angle a)
        {
            return (double)a.Value;
        }

        #endregion ConversionOperators

        #region StringMethods
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return new AngleFormatter().Format(format, this, formatProvider);
        }

        public string ToString(string format)
        {
            AngleFormatter fmt = new AngleFormatter();
            return fmt.Format(format, this, fmt);
        }

        public override string ToString()
        {
            return String.Empty;
        }
        #endregion StringMethods
    }
}
