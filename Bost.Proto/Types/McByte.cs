namespace Bost.Proto.Types
{
    public class McByte
    {
        public static bool TryParse(ref byte[] buffer, out sbyte result)
        {
            result = (sbyte)buffer[0];
            buffer = buffer[1..];
            return true;
        }
        public static byte[] ToBytes(sbyte value)
        {
            byte[] result = new byte[1];
            result[0] = (byte)value;
            return result;
        }
    }
}
