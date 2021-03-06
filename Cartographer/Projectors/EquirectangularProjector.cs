﻿using Cartographer.Renderers.Display;
using Cartographer.World;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cartographer.Projectors
{
    public class EquirectangularProjector : IProjector
    {
        public DisplayMap ProjectCells(List<DisplayCell> cells)
        {
            var displayCells = cells.Select(ProjectCell).Where(cell => cell != null).ToList();
            return new DisplayMap(displayCells);
        }

        public DisplayCell ProjectCell(DisplayCell cell)
        {
            var newCell = cell;
            newCell.Points = cell.Points.Select(ProjectPoint).ToArray();
            if (newCell.Points.Any(point => point == null))
                return null;
            return newCell;
        }

        public Point ProjectPoint(Point point)
        {
            var latitude = Math.Atan2(point.Z, Math.Sqrt(point.X * point.X + point.Y * point.Y));
            var longitude = Math.Atan2(point.Y, point.X);
                
            if (Math.Abs(longitude) >= Math.PI/1.0001)
                return null;

            return new Point(longitude, latitude, 0);
        }
    }
}
