using Cartographer.World.Cells;
using System.Drawing;

namespace Cartographer.World.Projectors
{
    public class HemisphericalRenderer : CellRenderer
    {
        public override DisplayCell RenderCell(Cell cell, CellRenderOptions options)
        {
            var newCell = base.RenderCell(cell, options);

            newCell.HasColor = true;
            if (cell.Longitude >= 0)
                newCell.Color = cell.Latitude >= 0 ? Color.Red : Color.Green;
            else
                newCell.Color = cell.Latitude >= 0 ? Color.Blue : Color.Yellow;

            return newCell;
        }
    }
}
