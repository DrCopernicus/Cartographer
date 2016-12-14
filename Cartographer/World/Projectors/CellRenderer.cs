using Cartographer.World.Cells;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Cartographer.World.Projectors
{
    public class CellRenderer
    {
        public List<DisplayCell> RenderCells(List<Cell> cells, CellRenderOptions options)
        {
            return cells.Select(cell => RenderCell(cell, options)).Where(cell => cell != null).Select(cell => cell.Value).ToList();
        }

        public DisplayCell? RenderCell(Cell cell, CellRenderOptions options)
        {
            var newCell = new DisplayCell();

            newCell.Points = cell.Points.ToArray();
            if (newCell.Points.Any(point => point == null))
                return null;

            newCell.HasOutline = options.ShowCellOutline;

            switch (options.Layer)
            {
                case RenderLayer.None:
                    newCell.HasColor = false;
                    break;
                case RenderLayer.Hemispherical:
                    newCell.HasColor = true;
                    if (cell.Longitude >= 0)
                        newCell.Color = cell.Latitude >= 0 ? Color.Red : Color.Green;
                    else
                        newCell.Color = cell.Latitude >= 0 ? Color.Blue : Color.Yellow;
                    break;
            }



            return newCell;
        }
    }
}
