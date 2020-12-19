using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using static Bost.Proxy.ProxyClient;

namespace Bost.Proxy
{
	public class Proxy2Server
	{
		public event MessageHandler OnReciveMessage;


		public Socket game;
		public Socket server;
		public IPAddress host;
		public bool IsConnected = false;

		public Proxy2Server(string host, int port)
		{
			this.host = IPAddress.Parse(host);
			this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			this.server.Connect(host, port);
		}

		public void Start()
		{
			IsConnected = true;
			Task.Run(() =>
			{
				while (IsConnected)
				{
					var buffer = new byte[8192];
					int size = server.Receive(buffer);
					if (size > 0)
					{
						var toSend = buffer[0..size];
						OnReciveMessage?.Invoke(this, toSend);
						game.Send(toSend);
					}
				}
			});
		}
	}
}
