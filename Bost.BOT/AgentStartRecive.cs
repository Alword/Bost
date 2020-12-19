using Bost.Proto;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public partial class Agent
	{
		private Socket _socket;
		private int _timeout;
		private const int _timeoutAmount = 5000;
		private const int _packetAwait = 100;

		private Task StartRecive()
		{
			return Task.Run(async () =>
			{
				while (!CancellationToken.IsCancellationRequested)
				{
					using (_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
					{
						try
						{
							_socket.Connect(_server, _port);
							await Login();
							while (_commandQueue.Any())
							{
								var queued = _commandQueue.Dequeue();
								await SendArray(queued);
							}
							byte[] array = new byte[256];
							while (_socket.Connected && !CancellationToken.IsCancellationRequested)
							{
								int length = _socket.Receive(array);
								if (length > 0)
								{
									_timeout = 0;
									OnRecive.Invoke(this, array[0..length]);
								}
								else
								{

									await Task.Delay(_packetAwait);
									_timeout += _packetAwait;
									if (_timeout > _timeoutAmount) _socket.Disconnect(false);
								}
							}
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
					}
					ConnectionListner.Reset();
				}
			});
		}
	}
}
