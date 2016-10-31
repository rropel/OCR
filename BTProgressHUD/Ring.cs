using System;
using UIKit;
#if __UNIFIED__

#else
using MonoTouch.UIKit;
#endif

namespace BTProgressHUD
{
	public class Ring
	{
		/// <summary>
		/// Ring color
		/// </summary>
		public UIColor Color = UIColor.White;
		/// <summary>
		/// Background color
		/// </summary>
		public UIColor BackgroundColor = UIColor.DarkGray;
		/// <summary>
		/// Progress update interval in milliseconds
		/// </summary>
		public Double ProgressUpdateInterval = 300;

		public void ResetStyle(bool isiOS7, UIColor colorToUse)
		{
			Color = colorToUse;
			BackgroundColor = isiOS7 ? UIColor.White : UIColor.DarkGray;
			ProgressUpdateInterval = 300;


		}
	}
}

