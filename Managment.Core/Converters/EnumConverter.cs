using MvvmCross.Converters;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Managment.Core.Converters
{
    public class EnumDisplayNameValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetEnumDisplayName((Enum)value);
        }

        public static string GetEnumDisplayName(Enum value)
        {
            var t = value.GetType();
            var ti = t.GetTypeInfo();
            var fi = ti.DeclaredFields.FirstOrDefault(x => x.Name == value.ToString());

            var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Name;
            }
            return value.ToString();
        }
    }
}
