using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class ServerDifficultyPacket : BasePacket
    {
        public override int PacketId => 0x0E;
        public byte Difficulty;
        public bool DifficultyLocked;
        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out Difficulty);
            McBoolean.TryParse(ref array, out DifficultyLocked);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"ServerDifficulty Difficulty: {GetDifficulty()} Locked: {DifficultyLocked}";
        }

        private string GetDifficulty()
        {
            string difficulty;
            if (Difficulty == 0)
            {
                difficulty = "peaceful";
            }
            else if (Difficulty == 1)
            {
                difficulty = "easy";

            }
            else if (Difficulty == 2)
            {
                difficulty = "normal";

            }
            else if (Difficulty == 3)
            {
                difficulty = "hard";
            }
            else
            {
                difficulty = Difficulty.ToString();
            }
            return difficulty;
        }
    }
}
