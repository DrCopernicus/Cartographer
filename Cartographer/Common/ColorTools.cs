
using System;
using System.Drawing;

namespace Cartographer.Common
{
    public static class ColorTools
    {
        public static Color Gradiated(Color minimumColor, Color maximumColor, double percent)
        {
            percent = Math.Min(Math.Max(0, percent), 1);

            var red = minimumColor.R + (maximumColor.R - minimumColor.R) * percent;
            var green = minimumColor.G + (maximumColor.G - minimumColor.G) * percent;
            var blue = minimumColor.B + (maximumColor.B - minimumColor.B) * percent;

            return Color.FromArgb(255, (int) red, (int) green, (int) blue);
        }
    }
}
