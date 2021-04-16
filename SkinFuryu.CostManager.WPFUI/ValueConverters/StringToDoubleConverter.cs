using SkinFuryu.CostManager.WPFUI.ValueConverters.Base;
using System;
using System.Globalization;

namespace SkinFuryu.CostManager.WPFUI.ValueConverters
{
    public class StringToDoubleConverter : BaseValueConverter<StringToDoubleConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value).ToString("N2");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse((string)value);
        }
    }
}
