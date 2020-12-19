using Bost.Proto.StreamReader.Enum;
using Bost.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;

namespace Bost.Proto.StreamReader.Middleware
{
	public class StateUpdateMiddleware : McMiddleware
	{
		private readonly Dictionary<(int, ConnectionStates, Bounds), Action<McConnectionContext>> rules;
		public StateUpdateMiddleware(McRequestDelegate _next) : base(_next)
		{
			rules = GetRules();
		}

		public override void Invoke(McConnectionContext ctx)
		{
			var key = (ctx.PacketId, ctx.ConnectionState, ctx.BoundTo);

			if (rules.ContainsKey(key))
			{
				rules[key].Invoke(ctx);
			}
			_next?.Invoke(ctx);
		}

		private Dictionary<(int, ConnectionStates, Bounds), Action<McConnectionContext>> GetRules()
		{
			return new Dictionary<(int, ConnectionStates, Bounds), Action<McConnectionContext>>
			{
				{(0x00,ConnectionStates.Handshaking,Bounds.Server),(e)=>e.ConnectionState = ConnectionStates.Login },
				{(0x00,ConnectionStates.Login,Bounds.Server),(e)=>{e.IsCompressed = true; e.ConnectionState = ConnectionStates.Play; } },

				{(0x03,ConnectionStates.Login,Bounds.Client),(e)=>e.IsCompressed = true },
				{(0x02,ConnectionStates.Login,Bounds.Client),(e)=>e.ConnectionState = ConnectionStates.Play },
			};
		}
	}
}
