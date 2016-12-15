using System.Collections.Generic;

namespace Cartographer.World.Cells.Simulators.Mantle
{
    public class HotSpot
    {
        public List<CellInHotSpot> Cells { get; set; }
        public int Age { get; set; }

        public HotSpot(List<CellInHotSpot> cells)
        {
            Cells = cells;
        }
    }
}
