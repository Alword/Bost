using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class JoinGamePacket : BasePacket
	{
		public override int PacketId => 0x24;

		public int EntityId; // The player's Entity ID (EID) (int!)
		public bool IsHardcore; // Boolean
		public Gamemodes Gamemode; // 0: Survival, 1: Creative, 2: Adventure, 3: Spectator. Bit 3 (0x8) is the hardcore flag. 
		public Gamemodes PreviousGamemode; //*
		public int WorldCount; //* Varint
		public string[] WorldNames; // Identifiers for all worlds on the server
		public NbtLib.NbtCompoundTag DimensionCodec; //*
		public NbtLib.NbtCompoundTag Dimension; // Int Enum 
		public string WorldName; //*
		public long HashedSeed; // Long
		public int MaxPlayers; // *Varint
		public int ViewDistance; // VarInt
		public bool ReducedDebugInfo; // Boolean
		public bool EnableRespawnScreen; // Boolean
		public bool IsDebug; //*
		public bool IsFlat; //*

		public override void Read(byte[] array)
		{
			McInt.TryParse(ref array, out EntityId);
			McBoolean.TryParse(ref array, out IsHardcore);
			if (McUnsignedByte.TryParse(ref array, out var gamemode)) Gamemode = (Gamemodes)gamemode;
			if (McByte.TryParse(ref array, out var previousGamemode)) PreviousGamemode = (Gamemodes)previousGamemode;
			McVarint.TryParse(ref array, out WorldCount);
			McStringArray.TryParse(WorldCount, ref array, out WorldNames);
			McNbtCompoundTag.TryParse(ref array, out DimensionCodec);
			McNbtCompoundTag.TryParse(ref array, out Dimension);
			McString.TryParse(ref array, out WorldName);
			McLong.TryParse(ref array, out HashedSeed);
			McVarint.TryParse(ref array, out MaxPlayers);
			McVarint.TryParse(ref array, out ViewDistance);
			McBoolean.TryParse(ref array, out ReducedDebugInfo);
			McBoolean.TryParse(ref array, out EnableRespawnScreen);
			McBoolean.TryParse(ref array, out IsDebug);
			McBoolean.TryParse(ref array, out IsFlat);
		}

		public override string ToString()
		{
			return $"JoinGame EntityId: {EntityId} IsHardcore: {IsHardcore} Gamemode: {Gamemode} PreviousGamemode: {PreviousGamemode} " +
				$"WorldCount: {WorldCount} WorldNames: {WorldNames} DimensionCodec: {DimensionCodec} " +
				$"Dimension: {Dimension} WorldNames: {WorldNames} HashedSeed: {HashedSeed} MaxPlayers: {MaxPlayers} " +
				$"ViewDistance: {ViewDistance} ReducedDebugInfo: {ReducedDebugInfo} EnableRespawnScreen: {EnableRespawnScreen} " +
				$"IsDebug: {IsDebug} IsFlat: {IsFlat}";
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}
	}
}
