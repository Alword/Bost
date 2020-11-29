using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class EntityAnimationPacket : BasePacket
	{
		public override int PacketId => 0x05;

		public int EntityId { get; set; }
		public Animation Animation { get; set; }

		public override void Read(byte[] array)
		{
			if (McVarint.TryParse(ref array, out int entityId)) EntityId = entityId;
			if (McByte.TryParse(ref array, out sbyte animation)) Animation = (Animation)animation;
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}
	}
}
