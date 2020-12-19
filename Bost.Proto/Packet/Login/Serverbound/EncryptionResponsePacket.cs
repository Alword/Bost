using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Login.Serverbound
{
	public class EncryptionResponsePacket : BasePacket
	{
		public override int PacketId => 0x01;

		public int SharedSecretLength; //Varint
		public byte[] SharedSecret; //Byte Array
		public int VerifyTokenLength; //Varint
		public byte[] VerifyToken; //Byte Array

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out SharedSecretLength);
			McByteArray.TryParse(ref array, out SharedSecret);
			McVarint.TryParse(ref array, out VerifyTokenLength);
			McByteArray.TryParse(ref array, out VerifyToken);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}
	}
}
