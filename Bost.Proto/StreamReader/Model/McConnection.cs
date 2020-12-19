using Bost.Proto.StreamReader.Middleware;

namespace Bost.Proto.StreamReader.Model
{
	public class McConnection
	{
		private readonly McConnectionContext ctx;

		private McMiddleware connectionMiddleware;
		public McConnection(McConnectionContext ctx)
		{
			this.ctx = ctx;
			var stateChange = new StateUpdateMiddleware(null);
			var command = new CommandMiddleware(stateChange.Invoke);
			var compression = new CompressionMiddleware(command.Invoke);
			connectionMiddleware = new MessageBuilderMiddleware(compression.Invoke);
		}

		public void Listen(object sender, byte[] array)
		{
#if (!DEBUG)
            try
            {
                ctx.Data = array;
                connectionMiddleware.Invoke(ctx);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{ctx} e:{e}");
                throw;
            }
#else
			ctx.Data = array;
			connectionMiddleware.Invoke(ctx);
#endif
		}
	}
}
