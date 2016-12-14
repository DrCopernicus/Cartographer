using Cartographer.Common;
using Cartographer.World.Cells;
using System.Drawing;

namespace Cartographer.World.Projectors
{
    public class MantleHeatRenderer : CellRenderer
    {
        public override DisplayCell RenderCell(Cell cell, CellRenderOptions options)
        {
            var newCell = base.RenderCell(cell, options);

            newCell.HasColor = true;
            newCell.Color = ColorTools.Gradiated(Color.DarkRed, Color.Yellow, cell.MantleLayer.Heat * 0.001);

            return newCell;
        }
    }
}
