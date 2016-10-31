using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace OCR.UI.iOS.Converters
{
    public class StringToImageConverter : MvxValueConverter<string, UIImage>
    {
        protected override UIImage Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return Helpers.Helpers.StringBase64ToImage(value);
        }
    }
}