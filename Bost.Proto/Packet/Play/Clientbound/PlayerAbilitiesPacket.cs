using Bost.Proto.Extentions;
using Bost.Proto.Types;
using System;
using System.Text;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class PlayerAbilitiesPacket : BasePacket
	{
		public override int PacketId => 0x30;

		public byte Flags;
		public float FlyingSpeed;
		public float FieldofViewModifier;

		public override void Read(byte[] array)
		{
			McUnsignedByte.TryParse(ref array, out Flags);
			McFloat.TryParse(ref array, out FlyingSpeed);
			McFloat.TryParse(ref array, out FieldofViewModifier);
		}
		public override string ToString()
		{
			return $"PlayerAbilities Flags: {GetFlags()} FlyingSpeed: {FlyingSpeed} FOV Modifier: {FieldofViewModifier}";
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		private string GetFlags()
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (Flags.IsChecked(0))
			{
				stringBuilder.Append("Invulnerable ");
			}
			if (Flags.IsChecked(1))
			{
				stringBuilder.Append("Flying ");
			}
			if (Flags.IsChecked(2))
			{
				stringBuilder.Append("Allow Flying ");
			}
			if (Flags.IsChecked(3))
			{
				stringBuilder.Append("Creative Mode (Instant Break) ");
			}
			return stringBuilder.ToString();
		}
	}
}
