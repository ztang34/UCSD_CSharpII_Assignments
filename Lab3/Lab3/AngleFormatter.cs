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
                return string.Empty;
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

        public int GetDecimalPlace(string format)
        {
            if(format.Length < 2 || !char.IsDigit(format[1]))
            {
                return DefaultDecimalPlace;
            }
            else
            {
                return int.Parse(format[1].ToString());
            }
        }
        
    }
}
