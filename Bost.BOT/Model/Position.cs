namespace Bost.BOT.Model
{
    public class Position
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override string ToString()
        {
            return $"XYZ {X:0.00} {Y:0.00} {Z:0.00}";
        }
    }
}
