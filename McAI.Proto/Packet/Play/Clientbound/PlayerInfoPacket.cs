using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class PlayerInfoPacket : BasePacket
    {
        public override int PacketId => 0x34;

        public int Action; //Varint
        public int NumberOfPlayers; //Varint
        public Player[] Players;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Action);
            McVarint.TryParse(ref array, out NumberOfPlayers);

            Players = new Player[NumberOfPlayers];
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Players[i] = new Player();
                Players[i].Read(ref array, Action);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Action:{Action}");
            if (Action == 4)
            {
                return stringBuilder.ToString(); ;
            }

            foreach (Player player in Players)
            {
                stringBuilder.AppendLine(player.ToString());
            }
            return $"[PlayerInfo] NumberOfPlayers:{NumberOfPlayers} Players:{stringBuilder}";
        }
    }
}
