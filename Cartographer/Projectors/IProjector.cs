using Cartographer.Renderers.Display;
using Cartographer.World;
using System.Collections.Generic;

namespace Cartographer.Projectors
{
    public interface IProjector
    {
        DisplayMap ProjectCells(List<DisplayCell> cells);
        DisplayCell ProjectCell(DisplayCell cell);
        Point ProjectPoint(Point point);
    }
}