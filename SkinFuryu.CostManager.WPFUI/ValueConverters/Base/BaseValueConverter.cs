using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SkinFuryu.CostManager.WPFUI.ValueConverters.Base
{
    /// <summary>
    /// Base model for converts to follow and inherit from
    /// </summary>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : BaseValueConverter<T>, new()
    {
        

        #region Private Propertie

        private static T converter = null;

        #endregion

        #region MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider) => converter ??= new T();

        #endregion

        /// <summary>
        /// Converts from the passed value to a wanted targeted value
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType">target type to convert to</param>
        /// <param name="parameter">extra paramter passed in</param>
        /// <param name="culture">Culture to add in</param>
        /// <returns>The Converted Value</returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Undoes the conversion of the value
        /// </summary>
        /// <param name="value">Value to unconvert</param>
        /// <param name="targetType">Target of type of the value to unconvert to</param>
        /// <param name="parameter">parameter passed in</param>
        /// <param name="culture">Culture to add in</param>
        /// <returns>the original value before conversion</returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
