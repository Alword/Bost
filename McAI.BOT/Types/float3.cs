namespace Bost.BOT.Model
{
    public struct Float3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Float3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}
