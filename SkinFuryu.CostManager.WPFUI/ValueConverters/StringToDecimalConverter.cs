using SkinFuryu.CostManager.WPFUI.ValueConverters.Base;
using System;
using System.Globalization;

namespace SkinFuryu.CostManager.WPFUI.ValueConverters
{
    public class StringToDecimalConverter : BaseValueConverter<StringToDecimalConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value).ToString("N3");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Parse((string)value);
        }
    }
}
