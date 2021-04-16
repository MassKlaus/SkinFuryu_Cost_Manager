using SkinFuryu.CostManager.WPFUI.ValueConverters.Base;
using System;
using System.Globalization;

namespace SkinFuryu.CostManager.WPFUI.ValueConverters
{
    public class DoubleToPercentageConverter : BaseValueConverter<DoubleToPercentageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value * 100).ToString();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse((string)value, NumberStyles.AllowCurrencySymbol, culture) / 100;
        }
    }
}
