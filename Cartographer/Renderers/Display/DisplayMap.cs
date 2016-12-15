using System.Collections.Generic;

namespace Cartographer.Renderers.Display
{
    public class DisplayMap
    {
        public List<DisplayCell> Cells { get; set; }

        public DisplayMap(List<DisplayCell> cells)
        {
            Cells = cells;
        }
    }
}
