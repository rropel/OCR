using System;
using UIKit;

namespace OCR.UI.iOS.Helpers
{
    public static class Helpers
    {
        public static UIImage StringBase64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);

            return imageBytes.ToImage();
        }
    }
}