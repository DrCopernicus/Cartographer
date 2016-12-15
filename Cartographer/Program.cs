using Cartographer.Projectors;
using Cartographer.Renderers;
using Cartographer.SVG;
using Cartographer.World;
using System;
using System.IO;

namespace Cartographer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Planet(5);

            p.Simulate(5000);

            var projector = new EquirectangularProjector();
            var renderer = new MantleHeatRenderer();
            var options = new CellRenderOptions
            {
                ShowCellOutline = false,
                ShowConvectionDirection = true
            };

            var projection = projector.ProjectCells(renderer.RenderCells(p.Cells, options));
            Console.WriteLine("{0} out of {1} displayed", projection.Cells.Count, p.Cells.Count);
            var s = SVGGenerator.GetSVG(projection);

            File.WriteAllText("testdatafromequirect.svg", s);
        }
    }
}
