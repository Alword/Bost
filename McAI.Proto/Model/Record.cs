using Bost.Proto.Types;

namespace Bost.Proto.Model
{
    public class Record
    {
        public byte HorizontalPosition; //Unsigned Byte
        public byte YCoordinate; //Unsigned Byte
        public int BlockID; //Varint

        public void Read(ref byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out HorizontalPosition);
            McUnsignedByte.TryParse(ref array, out YCoordinate);
            McVarint.TryParse(ref array, out BlockID);
        }

        public override string ToString()
        {
            return $"HorizontalPosition:{HorizontalPosition} YCoordinate:{YCoordinate} " +
                $"BlockID:{BlockID}";
        }
    }
}
