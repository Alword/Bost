using Bost.Proto.Enum;
using Bost.Proto.Packet.Handshaking.Serverbound;
using Bost.Proto.Packet.Login.Serverbound;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public partial class Agent
	{
		private Task Login()
		{
			HandshakePacket handshakePacket = new HandshakePacket()
			{
				ProtocolVersion = Program.CurrentProto,
				Address = _server,
				Port = _port,
				LoginState = LoginStates.Login,
			};
			List<byte> toSend = new List<byte>();
			Write(handshakePacket, false, toSend);

			LoginStartPacket loginStartPacket = new LoginStartPacket()
			{
				Name = _nickname
			};
			Write(loginStartPacket, false, toSend);
			return Send(toSend.ToArray());
		}
	}
}
