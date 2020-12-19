using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using static Bost.Proxy.ProxyClient;

namespace Bost.Proxy
{
	public class Game2Proxy
	{
		public event MessageHandler OnSendMessage;

		public Socket server; // send to server
		public Socket game; // send to game

		private IPAddress address; // proxy server
		private Socket socket; // lisnet connection
		public Game2Proxy(string host, int port)
		{
			this.server = null; // need to be configured
			this.address = IPAddress.Parse(host);
			this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			socket.Bind(new IPEndPoint(address, port + 1));
			socket.Listen(1);
			game = socket.Accept();
		}

		public void Start()
		{
			Task.Run(() =>
			{
				while (true)
				{
					var buffer = new byte[8192];
					int size = game.Receive(buffer);
					if (size > 0)
					{
						var toSend = buffer[0..size];
						OnSendMessage?.Invoke(this, toSend);
						server.Send(toSend);
					}
				}
			});
		}
	}
}
