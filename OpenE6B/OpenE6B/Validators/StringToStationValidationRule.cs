using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OpenE6B.Validators
{
    public class StringToStationValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input.Length != 4)
            {
               return new ValidationResult(false, "A valid station must contain 4 characters."); 
            } else if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult(false, "StationId must only contain letters.");
            }
            return new ValidationResult(true, "");
        }
    }
}
