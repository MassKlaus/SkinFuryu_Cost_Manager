using SkinFuryu.CostManager.WPFUI.ValueConverters.Base;
using System;
using System.Globalization;
using System.Windows;

namespace SkinFuryu.CostManager.WPFUI.ValueConverters
{
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
