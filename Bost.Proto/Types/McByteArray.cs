namespace Bost.Proto.Types
{
    public class McByteArray
    {
        public static bool TryParse(ref byte[] buffer, out byte[] result)
        {
            result = buffer;
            return true;
        }
        public static bool TryParse(int length, ref byte[] buffer, out byte[] result)
        {
            result = buffer[0..length];
            buffer = buffer[length..];
            return true;
        }
        public static byte[] ToBytes(byte[] value)
        {
            return value;
        }
    }
}
