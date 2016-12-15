using Cartographer.World.Cells;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Cartographer.Renderers.Display;

namespace Cartographer.Renderers
{
    public class HemisphericalRenderer : CellRenderer
    {
        public override List<DisplayCell> RenderCells(List<Cell> cells, CellRenderOptions options)
        {
            return cells.Select(cell => RenderCell(cell, options)).Where(cell => cell != null).ToList();
        }

        private DisplayCell RenderCell(Cell cell, CellRenderOptions options)
        {
            var newCell = RenderBaseCell(cell, options);

            newCell.HasColor = true;
            if (cell.Longitude >= 0)
                newCell.Color = cell.Latitude >= 0 ? Color.Red : Color.Green;
            else
                newCell.Color = cell.Latitude >= 0 ? Color.Blue : Color.Yellow;

            return newCell;
        }
    }
}
