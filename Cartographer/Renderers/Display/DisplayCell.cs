using System.Drawing;
using Point = Cartographer.World.Point;

namespace Cartographer.Renderers.Display
{
    public class DisplayCell
    {
        public Point[] Points;

        public bool HasOutline;
        public bool HasColor;
        public Color Color;
    }
}
