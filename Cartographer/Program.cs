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
//            Console.WriteLine(p.Cells.Count);
//            foreach (var cell in p.Cells)
//                Console.WriteLine(cell);

            var projection = new EquirectangularProjector().PlanetaryProjection(p);
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
                s += "<path\n style=\"fill:none;stroke:#000000;stroke-width:0.5px\"\n";
                s += "d=\"m" + cell + "z\"\n";
                s += "id=\"path" + i + "\"/>";
                i++;
            }
            s += "</g></svg>";

            File.WriteAllText("testdatafromequirect.svg", s);
        }
    }
}
