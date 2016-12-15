using Cartographer.Renderers.Display;
using System.Drawing;
using System.Text;

namespace Cartographer.SVG
{
    public static class SVGGenerator
    {
        public static string GetSVG(DisplayMap map)
        {
            var s = new StringBuilder(GetHeaderBlock());
            var i = 0;
            foreach (var cell in map.Cells)
            {
                s.Append(GetCell(cell, i));
                i++;
            }
            s.Append(GetClosingBlock());
            return s.ToString();
        }

        private static string GetHeaderBlock()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
<!-- Created with Inkscape (http://www.inkscape.org/) -->

<svg
xmlns:dc=""http://purl.org/dc/elements/1.1/""
xmlns:cc=""http://creativecommons.org/ns#""
xmlns:rdf=""http://www.w3.org/1999/02/22-rdf-syntax-ns#""
xmlns:svg=""http://www.w3.org/2000/svg""
xmlns=""http://www.w3.org/2000/svg""
xmlns:sodipodi=""http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd""
xmlns:inkscape=""http://www.inkscape.org/namespaces/inkscape""
width=""210mm""
height=""297mm""
viewBox=""0 0 744.09448819 1052.3622047""
id=""svg2""
version=""1.1""
inkscape:version=""0.91 r13725""
sodipodi:docname=""test.svg"">
<g
inkscape:label=""Layer 1""
inkscape:groupmode=""layer""
id=""layer1"">";
        }

        private static string GetClosingBlock()
        {
            return "</g></svg>";
        }

        private static string GetCell(DisplayCell cell, int id)
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
