using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Angle
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
                    if(value <0 || value >360)
                    {
                        int whole = (int)(value % 360);
                        value -= whole * 360 * Math.Sign(value);
                    }
                    return value;
                case AngleUnits.Gradians:
                    if (value < 0 || value > 400)
                    {
                        int whole = (int)(value % 400);
                        value -= whole * 400 * Math.Sign(value);
                    }
                    return value;
                case AngleUnits.Radians:
                    if (value < 0 || value > twoPi)
                    {
                        int whole = (int)(value % twoPi);
                        value -= whole * 400 * Math.Sign(value);
                    }
                    return value;
                case AngleUnits.Turns:
                    if(value < 0 || value > 1)
                    {
                        value -= (int)value * Math.Sign(value);
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


    }
}
