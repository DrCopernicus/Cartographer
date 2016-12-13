using System;
using System.Collections.Generic;

namespace Cartographer.World
{
    public class Planet
    {
        private List<Cell> _cells;

        public List<Cell> Cells { get { return _cells; } }

        public Planet(int layers)
        {
            InitializeCells(layers);
        }

        private void InitializeCells(int layers)
        {
            if (layers < 0)
                throw new Exception("Must initialize planet with 0 or more layers of icosahedron subdivision.");

            var cells = CreateIcosahedron();

            for (var i = 0; i < layers; i++)
            {
                var newCells = new List<Cell>();

                foreach (var cell in cells)
                    newCells.AddRange(cell.Subdivide());

                cells = newCells;
            }

            _cells = cells;
        }

        private List<Cell> CreateIcosahedron()
        {
            var invphi = 2.0/(1 + Math.Sqrt(5));

            //have you ever seen a developer so lazy that they just hardcode everything?

            var points = new Point[12];
            points[0] = new Point(-invphi, 0, 1).PushFrom(Point.Zero(), 1);
            points[1] = new Point(invphi, 0, 1).PushFrom(Point.Zero(), 1);
            points[2] = new Point(-invphi, 0, -1).PushFrom(Point.Zero(), 1);
            points[3] = new Point(invphi, 0, -1).PushFrom(Point.Zero(), 1);
            points[4] = new Point(0, 1, invphi).PushFrom(Point.Zero(), 1);
            points[5] = new Point(0, 1, -invphi).PushFrom(Point.Zero(), 1);
            points[6] = new Point(0, -1, invphi).PushFrom(Point.Zero(), 1);
            points[7] = new Point(0, -1, -invphi).PushFrom(Point.Zero(), 1);
            points[8] = new Point(1, invphi, 0).PushFrom(Point.Zero(), 1);
            points[9] = new Point(-1, invphi, 0).PushFrom(Point.Zero(), 1);
            points[10] = new Point(1, -invphi, 0).PushFrom(Point.Zero(), 1);
            points[11] = new Point(-1, -invphi, 0).PushFrom(Point.Zero(), 1);

            var cells = new List<Cell>
            {
                new Cell(points[0], points[6], points[1]),
                new Cell(points[0], points[11], points[6]),
                new Cell(points[1], points[4], points[0]),
                new Cell(points[1], points[8], points[4]),
                new Cell(points[1], points[10], points[8]),
                new Cell(points[2], points[5], points[3]),
                new Cell(points[2], points[9], points[5]),
                new Cell(points[2], points[11], points[9]),
                new Cell(points[3], points[7], points[2]),
                new Cell(points[3], points[10], points[7]),
                new Cell(points[4], points[8], points[5]),
                new Cell(points[4], points[9], points[0]),
                new Cell(points[5], points[8], points[3]),
                new Cell(points[5], points[9], points[4]),
                new Cell(points[6], points[10], points[1]),
                new Cell(points[6], points[11], points[7]),
                new Cell(points[7], points[10], points[6]),
                new Cell(points[7], points[11], points[2]),
                new Cell(points[8], points[10], points[3]),
                new Cell(points[9], points[11], points[0])
            };

            return cells;
        }
    }
}
