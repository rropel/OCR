using System.Drawing;
using UIKit;

namespace OCR.UI.iOS.Helpers
{
    public static class ControlFactory
    {
        public static UIButton GetRefreshButton()
        {
            return GetButton("RefreshIcon", "RefreshIcon_Highlighted");
        }

        public static UIButton GetPlayButton()
        {
            return GetButton("PlayIcon", "PlayIcon_Highlighted");
        }

        public static UIButton GetDoneButton()
        {
            return GetButton("TaskDoneIcon", "TaskDoneIcon_Highlighted");
        }

        private static UIButton GetButton(string icon, string iconHighlighted)
        {
            var iconImage = UIImage.FromBundle(icon);
            var iconHighlightedImage = UIImage.FromBundle(iconHighlighted);
            var button = new UIButton(new RectangleF(0, 0, (float)iconImage.Size.Width, (float)iconImage.Size.Height));
            button.SetBackgroundImage(iconImage, UIControlState.Normal);
            button.SetBackgroundImage(iconHighlightedImage, UIControlState.Highlighted);
            return button;
        }
    }
}