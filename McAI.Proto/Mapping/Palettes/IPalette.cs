using McAI.Proto.Mapping.Generator;

namespace McAI.Proto.Mapping.Palettes
{
    public interface IPalette
    {
        uint IdForState(BlockState state);
        BlockState StateForId(uint id);
        byte GetBitsPerBlock();
        void Read(ref byte[] data);
        void Write(byte[] data);
    }
}
