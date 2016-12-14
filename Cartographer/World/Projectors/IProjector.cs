using Cartographer.World.Cells;
using System.Collections.Generic;

namespace Cartographer.World.Projectors
{
    public interface IProjector
    {
        List<DisplayCell> ProjectCells(List<DisplayCell> cells);
        DisplayCell ProjectCell(DisplayCell cell);
        Point ProjectPoint(Point point);
    }
}