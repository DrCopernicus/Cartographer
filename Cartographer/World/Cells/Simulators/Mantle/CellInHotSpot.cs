namespace Cartographer.World.Cells.Simulators.Mantle
{
    public struct CellInHotSpot
    {
        public double Intensity;
        public Cell Cell;

        public CellInHotSpot(double intensity, Cell cell)
        {
            Intensity = intensity;
            Cell = cell;
        }
    }
}