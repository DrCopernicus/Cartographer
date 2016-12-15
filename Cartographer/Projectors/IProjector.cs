using System.Collections.Generic;
using Cartographer.World;
using Cartographer.World.Cells;

namespace Cartographer.Projectors
{
    public interface IProjector
    {
        List<DisplayCell> ProjectCells(List<DisplayCell> cells);
        DisplayCell ProjectCell(DisplayCell cell);
        Point ProjectPoint(Point point);
    }
}