using Cartographer.Common;
using System.Collections.Generic;
using System.Linq;

namespace Cartographer.World.Cells.Simulators.Mantle
{
    public class MantleSimulator
    {
        private readonly List<HotSpot> _hotSpots = new List<HotSpot>();

        public void Simulate(List<Cell> cells)
        {
            if (RandomTools.Chance(0.0001))
            {
                var startPoint = RandomTools.NextElement(cells);

                _hotSpots.Add(new HotSpot(new List<CellInHotSpot>{new CellInHotSpot(1.0, startPoint)}));
            }

            foreach (var hotspot in _hotSpots.ToList())
            {
                hotspot.Age++;
                if (hotspot.Age >= RandomTools.NextGaussian(1000, 50))
                    _hotSpots.Remove(hotspot);

                foreach (var cell in hotspot.Cells)
                    cell.Cell.MantleLayer.Heat += RandomTools.NextInt(900, 1100);
            }

            foreach (var cell in cells)
            {
                foreach (var neighbor in cell.Neighbors)
                {
                    var heatTransferred = 0.4*(cell.MantleLayer.Heat - neighbor.MantleLayer.Heat);
                    cell.MantleLayer.Heat -= heatTransferred;
                    neighbor.MantleLayer.Heat += heatTransferred;
                }
            }
        }
    }
}
