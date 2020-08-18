using Bost.Proto.Types;

namespace Bost.Proto.Model
{
    public struct Position
    {
        public int X;
        public int Y;
        public int Z;

        public void Read(ref byte[] array)
        {
            McLong.TryParse(ref array, out long val);
            X = (int)(val >> 38);
            Y = (int)(val & 0xFFF);
            Z = (int)(val << 26 >> 38);
        }

        public byte[] Write()
        {
            long val = (((long)X & 0x3FFFFFF) << 38) | (((long)Z & 0x3FFFFFF) << 12) | ((long)Y & 0xFFF);
            return McLong.ToBytes(val);
        }

        public override string ToString()
        {
            return $"XYZ:{X} {Y} {Z}";
        }
    }
}
