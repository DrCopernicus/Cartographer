using Cartographer.Common;
using Cartographer.World.Cells;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Cartographer.Renderers.Display;

namespace Cartographer.Renderers
{
    public class MantleHeatRenderer : CellRenderer
    {
        public override List<DisplayCell> RenderCells(List<Cell> cells, CellRenderOptions options)
        {
            var maxHeat = cells.Max(cell => cell.MantleLayer.Heat);
            var minHeat = cells.Min(cell => cell.MantleLayer.Heat);

            return cells.Select(cell => RenderCell(cell, options, maxHeat, minHeat)).Where(cell => cell != null).ToList();
        }

        private DisplayCell RenderCell(Cell cell, CellRenderOptions options, double maxHeat, double minHeat)
        {
            var newCell = RenderBaseCell(cell, options);

            var percentColor = (cell.MantleLayer.Heat - minHeat)/(maxHeat - minHeat);

            newCell.HasColor = true;
            newCell.Color = ColorTools.Gradiated(Color.DarkRed, Color.Yellow, double.IsNaN(percentColor) ? 1.0 : percentColor);

            return newCell;
        }
    }
}
