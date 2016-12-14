using Cartographer.World.Cells.Layers;
using System.Collections.Generic;
using System.Linq;

namespace Cartographer.World.Cells
{
    public class Cell : ICell
    {
        private Point[] _points;
        public Point[] Points { get { return _points; } }

        private double _windDirection;
        private double _windHeat;
        private List<Cell> _neighbors;

        public double WindDirection { get { return _windDirection; } }
        public double WindHeat { get { return _windDirection; } }

        public MantleLayer MantleLayer = new MantleLayer();

        public double Latitude
        {
            get { return Points.Select(point => point.GetLatitude(Point.Zero())).Average(); }
        }

        public double Longitude
        {
            get { return Points.Select(point => point.GetLongitude(Point.Zero())).Average(); }
        }

        public Cell(Point[] points)
        {
            _windDirection = 0;
            _windHeat = 0;
            _points = points;
        }

        public Cell(Point a, Point b, Point c)
        {
            _windDirection = 0;
            _windHeat = 0;
            _points = new[] { a, b, c };
        }

        public void Simulate()
        {
            MantleLayer.Simulate(this);
        }

        public List<Cell> Subdivide()
        {
            var a = Points[0].Between(Points[1]).PushFrom(Point.Zero(), 1);
            var b = Points[1].Between(Points[2]).PushFrom(Point.Zero(), 1);
            var c = Points[2].Between(Points[0]).PushFrom(Point.Zero(), 1);

            var list = new List<Cell>
            {
                new Cell(Points[0], a, c),
                new Cell(Points[1], b, a),
                new Cell(Points[2], c, b),
                new Cell(a, b, c)
            };

            return list;
        }
    }
}
