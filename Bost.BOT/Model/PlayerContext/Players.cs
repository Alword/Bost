using System;
using System.Collections.Generic;

namespace Bost.Agent.Model.PlayerContext
{
	public class Players
	{
		private readonly List<Player> players;
		private readonly Dictionary<int, Player> idToPlayer;
		private readonly Dictionary<Guid, Player> guidPlayer;
		private readonly Dictionary<string, Player> nickPlayer;

		public event EventHandler<Player> OnRemovePlayer;
		public event EventHandler<Player> OnLinkPlayer;

		public Players()
		{
			players = new List<Player>();
			idToPlayer = new Dictionary<int, Player>();
			guidPlayer = new Dictionary<Guid, Player>();
			nickPlayer = new Dictionary<string, Player>();
		}
		public void Add(Player player)
		{
			if (guidPlayer.ContainsKey(player.UUID))
				return;

			players.Add(player);
			guidPlayer.Add(player.UUID, player);
			nickPlayer.Add(player.Nickname, player);
		}
		public void Remove(Guid guid)
		{
			guidPlayer.ContainsKey(guid);
			Player toDelete = guidPlayer[guid];
			guidPlayer.Remove(guid);
			nickPlayer.Remove(toDelete.Nickname);
			idToPlayer.Remove(toDelete.CurrentEntityId);
			OnRemovePlayer?.Invoke(this, toDelete);
		}
		public void Link(int entityId, Guid guid)
		{
			if (!guidPlayer.ContainsKey(guid) || idToPlayer.ContainsKey(entityId)) return;
			Player toLink = guidPlayer[guid];
			toLink.CurrentEntityId = entityId;
			idToPlayer.Add(entityId, toLink);
			OnLinkPlayer?.Invoke(this, toLink);
		}
		public Player ContainsNick(string name)
		{
			if (nickPlayer.ContainsKey(name))
				return nickPlayer[name];
			return Player.Empty;
		}

		public Player ContainsGuid(Guid guid)
		{
			if (guidPlayer.ContainsKey(guid))
				return guidPlayer[guid];
			return Player.Empty;
		}

		public Player ContainsEid(int entityId)
		{
			if (idToPlayer.ContainsKey(entityId))
				return idToPlayer[entityId];
			return Player.Empty;
		}
	}
}
