using System;
#if __IOS__
using CoreGraphics;
using UIKit;
#endif

namespace SharedProject.Classes
	{

	/// <summary>
	/// App global Classes.
	/// </summary>
	public static class AppGlobal
		{
		/// <summary>
		/// Server.
		/// </summary>
		public static class Server
			{
			//public static string Address => "http://goftagram.com/sarkoobi/status-code/post/sample/";
			//public static string Address => "http://localhost:5000/";


			public static string Address => (UserHolder.DefaultServer == "8050") ? "http://communere.com:8050/" : "http://communere.com:8060/";
			}

		/// <summary>
		/// Frames.
		/// </summary>
       
		public static class Frames
			{
#if __IOS__
            public static CGRect OverlayerBounds => new CGRect((UIScreen.MainScreen.Bounds.Width / 2) - 80, (UIScreen.MainScreen.Bounds.Height / 2) - 80, 160, 160);
			public static CGRect Frame => UIScreen.MainScreen.Bounds;
#endif
        }

		/// <summary>
		/// Colors.
		/// </summary>
		public static class Color
			{
#if __IOS__
            public static UIColor GreenColor => UIColor.FromRGB(38, 135, 58); //26873a
			public static UIColor LightGreenColor => UIColor.FromRGB(73, 168, 63);
			public static UIColor LightBlueColor => UIColor.FromRGB(130, 189, 196);
			public static UIColor BlueColor => UIColor.FromRGB(11, 162, 233); //0ba2e9
			public static UIColor LightGrayColor => UIColor.FromRGB(236, 236, 236);
			public static UIColor BackGroundGray => UIColor.FromRGB(210, 210, 210);
			public static UIColor OrangeColor => UIColor.FromRGB(247, 148, 29);
			public static UIColor BorderGrayColor => UIColor.FromRGB(230, 230, 230);
#endif
        }


		/// <summary>
		/// Fonts Names.
		/// </summary>
		public static class Fonts
			{
			//public static string Light => "MyriadPro-Light";
			//public static string Regular => "MyriadPro-Regular";
			//public static string Italic => "";
			//public static string Bold => "MyriadPro-Bold";
			//public static string SemiBold => "MyriadPro-SemiboldCond";
			//public static string BoldItalic => "";

			//public static string Light => "EffraLight-Regular";
			//public static string Regular => "EffraLight-Regular";
			//public static string Italic => "";
			//public static string Bold => "Effra-Bold";
			//public static string SemiBold => "EffraMedium-Regular";
			//public static string BoldItalic => "Effra-BoldItalic";


			public static string Light => "HelveticaNeue-Light";
			public static string Regular => "HelveticaNeue";
			public static string Italic => "HelveticaNeue-Italic";
			public static string Bold => "HelveticaNeue-Bold";
			public static string SemiBold => "HelveticaNeue-Medium";
			public static string BoldItalic => "HelveticaNeue-BoldItalic";


			}

		public static class SampleText
			{
			public static string Lorem_ipsum => "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercit";
			}
		}
	}
