using Cartographer.World.Cells;
using System.Drawing;

namespace Cartographer.Renderer
{
    public static class CellSVGGenerator
    {
        public static string GetSVG(DisplayCell cell, int id)
        {
            var s = "";

            s += string.Format("<path {0}", GetStyle(cell));
            s += " d=\"m" + string.Format("{0}L{1}L{2}", cell.Points[0], cell.Points[1], cell.Points[2]) + "z\"";
            s += " id=\"path" + id + "\"/>";

            return s;
        }

        private static string GetStyle(DisplayCell cell)
        {
            return string.Format("style=\"{0};{1}\"", GetFillOptions(cell), GetStrokeOptions(cell));
        }

        private static string GetFillOptions(DisplayCell cell)
        {
            if (cell.HasColor)
                return string.Format("fill:{0}", ColorToHex(cell.Color));

            return "fill:none";
        }

        private static string GetStrokeOptions(DisplayCell cell)
        {
            if (cell.HasOutline)
                return "stroke:#000000;stroke-width:0.2px";

            return "stroke:none";
        }

        private static string ColorToHex(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }
    }
}
