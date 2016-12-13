using System.Collections.Generic;

namespace Cartographer.World
{
    public class Cell
    {
        public Point[] Points;

        private double _windDirection;
        private double _windHeat;
        private List<Cell> _neighbors;

        public double WindDirection { get { return _windDirection; } }
        public double WindHeat { get { return _windDirection; } }

        public Cell(Point[] points)
        {
            _windDirection = 0;
            _windHeat = 0;
            Points = points;
        }

        public Cell(Point a, Point b, Point c)
        {
            _windDirection = 0;
            _windHeat = 0;
            Points = new []{a, b, c};
        }

        public void Simulate()
        {
            
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

        public override string ToString()
        {
            return string.Format("{0}L{1}L{2}", Points[0], Points[1], Points[2]);
        }
    }
}
