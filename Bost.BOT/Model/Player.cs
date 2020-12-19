using Bost.Proto.Enum;
using System;

namespace Bost.Agent.Model
{
	public class Player : Transform
	{
		public int CurrentEntityId { get; set; }
		public string Nickname { get; set; }
		public Gamemods Gamemode { get; set; }
		public Guid UUID { get; set; }
		public int Health { get; set; }
		public int Food { get; set; }
		public float FoodS { get; set; }
		public Inventory Inventory { get; set; }
		public int Ping { get; set; }

		public static Player Empty => new Player();

		public override bool Equals(object obj)
		{
			return obj is Player player &&
				   Nickname == player.Nickname;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Nickname);
		}
	}
}
