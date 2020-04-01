using McAI.Proto.Enum;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class JoinGamePacket : BasePacket
    {
        public override int PacketId => 0x26;

        public int EntityId; // The player's Entity ID (EID) (int!)
        public byte Gamemode; // 0: Survival, 1: Creative, 2: Adventure, 3: Spectator. Bit 3 (0x8) is the hardcore flag. 
        public Dimensions Dimension; // Int Enum 
        public long HashedSeed; // Long
        public byte MaxPlayers; // Unsigned Byte 
        public string LevelType; // String Enum (16)
        public int ViewDistance; // VarInt
        public bool ReducedDebugInfo; // Boolean
        public bool EnableRespawnScreen; // Boolean

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out EntityId);
            McUnsignedByte.TryParse(ref array, out Gamemode);
            McInt.TryParse(ref array, out int dimension);
            Dimension = (Dimensions)dimension;
            McLong.TryParse(ref array, out HashedSeed);
            McUnsignedByte.TryParse(ref array, out MaxPlayers);
            McString.TryParse(ref array, out LevelType);
            McVarint.TryParse(ref array, out ViewDistance);
            McBoolean.TryParse(ref array, out ReducedDebugInfo);
            McBoolean.TryParse(ref array, out EnableRespawnScreen);
        }

        public override string ToString()
        {
            return $"[JoinGame|0x{PacketId:X02}] EntityId: {EntityId} Gamemode: {Gamemode} " +
                $"Dimension: {Dimension} HashedSeed: {HashedSeed} MaxPlayers: {MaxPlayers} " +
                $"LevelType: {LevelType} ViewDistance: {ViewDistance} ReducedDebugInfo: {ReducedDebugInfo} " +
                $"EnableRespawnScreen: {EnableRespawnScreen}";
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
