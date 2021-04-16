using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SkinFuryu.CostManager.WPFUI.ValidationRules
{
    /// <summary>
    /// Handles Validating Decimal Numbers Before Conversion
    /// </summary>
    public class DecimalValidation : ValidationRule
    {
        /// <summary>
        /// Validates that the value passed in is a Valid Number
        /// </summary>
        /// <param name="value">Value Passed in as an object</param>
        /// <param name="cultureInfo">the culture that the string is following</param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is decimal || decimal.TryParse((string) value, NumberStyles.Any, cultureInfo, out _))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "The given value in not a decimal number");
        }
    }
}
