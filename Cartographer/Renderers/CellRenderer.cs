using Cartographer.World.Cells;
using System.Collections.Generic;
using System.Linq;

namespace Cartographer.Renderers
{
    public class CellRenderer
    {
        public virtual List<DisplayCell> RenderCells(List<Cell> cells, CellRenderOptions options)
        {
            return cells.Select(cell => RenderBaseCell(cell, options)).Where(cell => cell != null).ToList();
        }

        protected DisplayCell RenderBaseCell(Cell cell, CellRenderOptions options)
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
