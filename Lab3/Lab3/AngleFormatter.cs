using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class AngleFormatter : ICustomFormatter, IFormatProvider
    {
        public const int DefaultDecimalPlace = -1;
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("Variable is not set to an instance of object!");            
            }
            else if (arg is Angle)
            {
                Angle a = arg as Angle;
                decimal value;
                
                if(String.IsNullOrWhiteSpace(format) || string.IsNullOrEmpty(format))
                {
                    return a.Value.ToString("f2") + a.Units.ToSymbol();
                }
                else
                {
                    char unit = char.ToLower(format[0]); //ignore case
                    string decimalPlace = GetDecimalPlace(format,unit); 

                    switch (unit)
                    {
                        case 'c':
                            value = a.Value; 
                            return value.ToString(decimalPlace) + a.Units.ToSymbol();
                        case 'd':
                            value = a.ToDegrees().Value;
                            return value.ToString(decimalPlace) + AngleUnits.Degrees.ToSymbol();
                        case 'g':
                            value = a.ToGradians().Value;
                            return value.ToString(decimalPlace) + AngleUnits.Degrees.ToSymbol();
                        case 'p':
                            value = a.ToRadians().Value / (decimal)Math.PI;
                            return value.ToString(decimalPlace) + "π" + AngleUnits.Radians.ToSymbol();
                        case 'r':
                            value = a.ToRadians().Value;
                            return value.ToString(decimalPlace) + AngleUnits.Radians.ToSymbol();
                        case 't':
                            value = a.ToTurns().Value;
                            return value.ToString(decimalPlace) + AngleUnits.Turns.ToSymbol();
                        default:
                            value = a.Value;
                            return value.ToString(decimalPlace) + a.Units.ToSymbol();
                    }
                }
               
            }
            else if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, formatProvider);
            }
            else
            {
                return arg.ToString();
            }
        }

        public object GetFormat(Type formatType)
        {
            if (typeof(ICustomFormatter).Equals(formatType))
            {
                return this;
            }
            return null;
        }

        public string GetDecimalPlace(string format, char unit)
        {
            if(String.IsNullOrEmpty(format) || String.IsNullOrWhiteSpace(format) || (format.Length >= 2 && !char.IsDigit(format[1]))) //invalid format code
            {
                return "f2";
            }
            else if (format.Length < 2) //not specifying decimal place
            {
                if (unit == 'p' || unit == 'r')
                {
                    return "f5"; //default decimal place for radian
                }
                else
                {
                    return "f2"; //default decimal place for all other units
                }

            }
            else
            {
                return "f" + format[1].ToString();
            }
        }
        
    }
}
