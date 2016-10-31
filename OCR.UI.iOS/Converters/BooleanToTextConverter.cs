using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace OCR.UI.iOS.Converters
{
    public class BooleanToTextConverter : MvxValueConverter<bool, string>
    {
        protected override string Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value
                ? "Yes"
                : "No";
        }
    }
}