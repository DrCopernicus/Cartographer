using Cartographer.Renderer;
using Cartographer.World;
using Cartographer.World.Projectors;
using System;
using System.IO;

namespace Cartographer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Planet(5);

            p.Simulate(500);

            var projector = new EquirectangularProjector();
            var renderer = new MantleHeatRenderer();
            var options = new CellRenderOptions
            {
                ShowCellOutline = false,
                ShowConvectionDirection = true
            };

            var projection = projector.ProjectCells(renderer.RenderCells(p.Cells, options));
            Console.WriteLine("{0} out of {1} displayed", projection.Count, p.Cells.Count);
            var s =
@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
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
            var i = 0;
            foreach (var cell in projection)
            {
                s += CellSVGGenerator.GetSVG(cell, i);
                i++;
            }
            s += "</g></svg>";

            File.WriteAllText("testdatafromequirect.svg", s);
        }
    }
}
