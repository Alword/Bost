using Bost.Proto.Extentions;
using Bost.Proto.StreamReader.Enum;

namespace Bost.Proto.StreamReader.Model
{
	public class McConnectionContext
	{
		public readonly PacketEventHub packetEventHub;
		public readonly GenericEventHub genericEventHub;
		public bool IsCompressed { get; set; }
		public bool Encryption { get; set; }
		public string EncryptionPrivatekey { get; set; }
		public string EncryptionPuivatekey { get; set; }


		public int Length;
		public int CompressionLength;
		public int PacketId;
		public ConnectionStates ConnectionState { get; set; }
		public Bounds BoundTo { get; set; }
		public byte[] Data;

		public McConnectionContext(PacketEventHub packetEventHub, GenericEventHub genericEventHub)
		{
			this.packetEventHub = packetEventHub;
			this.genericEventHub = genericEventHub;
		}

		public override string ToString()
		{
			return $"Error: 0x{PacketId:X02} |{ConnectionState} | {BoundTo} | {CompressionLength} | {Data.ToHexString()}";
		}
	}
}
