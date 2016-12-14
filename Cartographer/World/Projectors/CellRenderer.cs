using Cartographer.World.Cells;
using System.Collections.Generic;
using System.Linq;

namespace Cartographer.World.Projectors
{
    public class CellRenderer
    {
        public List<DisplayCell> RenderCells(List<Cell> cells, CellRenderOptions options)
        {
            return cells.Select(cell => RenderCell(cell, options)).Where(cell => cell != null).ToList();
        }

        public virtual DisplayCell RenderCell(Cell cell, CellRenderOptions options)
        {
            var newCell = new DisplayCell();

            newCell.Points = cell.Points.ToArray();
            if (newCell.Points.Any(point => point == null))
                return null;

            newCell.HasOutline = options.ShowCellOutline;

            return newCell;
        }
    }
}
