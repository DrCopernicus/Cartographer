using System.Drawing;

namespace Cartographer.World.Cells
{
    public struct DisplayCell
    {
        public Point[] Points;

        public bool HasOutline;
        public bool HasColor;
        public Color Color;
    }
}
