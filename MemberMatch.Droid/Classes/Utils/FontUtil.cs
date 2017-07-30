using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace MemberMatch.Droid.Classes.Utils
{
    class FontUtil
    {
        public static string Effra_Std = "fonts/Effra_Std";
        public static string Effra_Std_BdIt = "fonts/Effra_Std_BdIt";
        public static string Effra_Std_Lt = "fonts/Effra_Std_Lt";
        public static string Effra_Std_Md = "fonts/Effra_Std_Md";
        public static string Myriad_Pro_Bold = "fonts/Myriad-Pro-Bold";
        public static string Myriad_Pro_Light = "fonts/Myriad-Pro-Light";
        public static string Myriad_Pro_Regular = "fonts/Myriad-Pro-Regular";
        public static string Myriad_Pro_Semibold = "fonts/Myriad-Pro-Semibold";


        public static void SettingEditTextEffra_Std(EditText editText, Context context)
        {
            Typeface typeface = Typeface.CreateFromAsset(context.Assets, Effra_Std);
            editText.Typeface = typeface;
        }

        public static void SettingButtonEffra_Std(Button button, Context context)
        {
            Typeface typeface = Typeface.CreateFromAsset(context.Assets, Effra_Std);
            button.Typeface = typeface;
        }

        public static void SettingTextViewEffra_Std(TextView textview, Context context)
        {
            Typeface typeface = Typeface.CreateFromAsset(context.Assets, Effra_Std);
            textview.Typeface = typeface;
        }

        public static void SettingEditTextEffra_Std_BdIt(EditText editText, Context context)
        {
            Typeface typeface = Typeface.CreateFromAsset(context.Assets, Effra_Std);
            editText.Typeface = typeface;
        }

        public static void SettingButtonEffra_Std_BdIt(Button button, Context context)
        {
            Typeface typeface = Typeface.CreateFromAsset(context.Assets, Effra_Std);
            button.Typeface = typeface;
        }

        public static void SettingTextViewEffra_Std_BdIt(TextView textview, Context context)
        {
            Typeface typeface = Typeface.CreateFromAsset(context.Assets, Effra_Std);
            textview.Typeface = typeface;
        }
    }
}