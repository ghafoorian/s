using System;
namespace SharedProject.Classes
{
#if __IOS__
    public static class Handicap
    {
        public static string Slider (nfloat value)
        {

            var slider = Convert.ToInt32 (value * 64);

            slider = (slider - 10);

            var output = (slider.ToString ().Replace ('-', '+'));

            return output;

        }

        public static float SetValue (float value)
        {
			if (value >= 54) value = 54;

            value = value + 10;
            float slider = value / 64;
            return slider;
        }
    }
#endif
}
