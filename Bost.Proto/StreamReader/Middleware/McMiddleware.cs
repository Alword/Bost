using Bost.Proto.StreamReader.Model;

namespace Bost.Proto.StreamReader
{
	public abstract class McMiddleware
	{
		public delegate void McRequestDelegate(McConnectionContext mcConnectionContext);

		protected readonly McRequestDelegate _next;

		public McMiddleware(McRequestDelegate _next)
		{
			this._next = _next;
		}

		public abstract void Invoke(McConnectionContext mcConnectionContext);
	}
}
