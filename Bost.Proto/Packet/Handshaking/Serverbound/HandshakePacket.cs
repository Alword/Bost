using Bost.Proto.Enum;
using Bost.Proto.Types;
using System.Collections.Generic;

namespace Bost.Proto.Packet.Handshaking.Serverbound
{
	public class HandshakePacket : BasePacket
	{
		/// <summary>See protocol version numbers(currently 754 in Minecraft 1.16.4)</summary>
		public int ProtocolVersion;
		/// <summary>Hostname or IP, e.g. localhost or 127.0.0.1, that was used to connect.</summary>
		public string Address;
		/// <summary>Default is 25565. The Notchian server does not use this information.</summary>
		public ushort Port;
		/// <summary>
		///  Varint 1 for status, 2 for login <seealso cref="LoginStates"/>
		/// </summary>
		public LoginStates LoginState;
		public override int PacketId => 0x00;

		public HandshakePacket() { }

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out ProtocolVersion);

			McString.TryParse(ref array, out Address);

			McUnsignedShort.TryParse(ref array, out Port);

			McVarint.TryParse(ref array, out int loginState);
			LoginState = (LoginStates)loginState;
		}

		public override string ToString()
		{
			return $"Handshake PV: {ProtocolVersion} Address: {Address} Port:{Port} LoginState: {LoginState}";
		}

		public override byte[] Write()
		{
			List<byte> bytes = new List<byte>();
			bytes.AddRange(McVarint.ToBytes(ProtocolVersion));
			bytes.AddRange(McString.ToBytes(Address));
			bytes.AddRange(McUnsignedShort.ToBytes(Port));
			bytes.AddRange(McVarint.ToBytes((int)LoginState));
			return bytes.ToArray();
		}
	}
}
