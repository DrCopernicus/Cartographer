using System;
using System.Collections.Generic;
using System.Linq;

namespace Cartographer.World
{
    public class EquirectangularProjector
    {
        public List<Cell> PlanetaryProjection(Planet planet)
        {
            return planet.Cells.Select(ProjectCell).Where(cell => cell != null).ToList();
        }

        public Cell ProjectCell(Cell cell)
        {
            var newCell = new Cell(cell.Points.Select(ProjectPoint).ToArray());
            if (newCell.Points.Any(point => point == null))
                return null;
            return newCell;
        }

        public Point ProjectPoint(Point point)
        {
            var x = point.X;
            var y = point.Y;
            var z = point.Z;

            var latitude = Math.Atan2(z, Math.Sqrt(x * x + y * y));
            var longitude = Math.Atan2(y, x);

//            var longitude = Math.Atan2(y, x);
//            var latitude = Math.Acos(z / Math.Sqrt(x * x + y * y + z * z));
//            if (Math.Abs(latitude) >= Math.PI)
//                return null;
                
            if (Math.Abs(longitude) >= Math.PI/1.001)
                return null;

            return new Point(longitude, latitude, 0);
        }
    }
}
