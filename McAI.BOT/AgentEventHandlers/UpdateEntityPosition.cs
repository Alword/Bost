using McAI.BOT.Model;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class UpdateEntityPosition : BaseAgentEvent
    {
        private readonly Dictionary<int, Transform> Entitys;
        public UpdateEntityPosition(Agent agent) : base(agent)
        {
            Entitys = agent.gameState.Entitys;
        }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            if (type.PacketId == 0x05)
            {
                var data = (SpawnPlayerPacket)packet;
                Transform transform = new Transform();
                transform.Position.X = data.X;
                transform.Position.Y = data.Y;
                transform.Position.Z = data.Z;
                transform.Rotation.Yaw = data.Yaw;
                transform.Rotation.Pitch = data.Pitch;
                Entitys.Add(data.EntityID, transform);
            }

            else if (type.PacketId == 0x29)
            {
                var data = (EntityPositionPacket)packet;
                if (Entitys.ContainsKey(data.EntityID))
                {
                    Transform transform = Entitys[data.EntityID];
                    transform.Position.X = (transform.Position.X * 4096 + data.DeltaX) / 4096;
                    transform.Position.Y = (transform.Position.Y * 4096 + data.DeltaY) / 4096;
                    transform.Position.Z = (transform.Position.Z * 4096 + data.DeltaZ) / 4096;
                    transform.OnGround = data.OnGround;

                    Console.WriteLine($"{transform.Position}");
                }
            }
            else if (type.PacketId == 0x2A)
            {
                var data = (EntityPositionAndRotationPacket)packet;
                if (Entitys.ContainsKey(data.EntityId))
                {
                    Transform transform = Entitys[data.EntityId];
                    transform.Position.X = (transform.Position.X * 4096 + data.DeltaX) / 4096;
                    transform.Position.Y = (transform.Position.Y * 4096 + data.DeltaY) / 4096;
                    transform.Position.Z = (transform.Position.Z * 4096 + data.DeltaZ) / 4096;
                    transform.Rotation.Yaw = data.Yaw;
                    transform.Rotation.Pitch = data.Pitch;
                    transform.OnGround = data.OnGround;

                    Console.WriteLine($"{transform.Position}");
                }
            }
            else if (type.PacketId == 0x57)
            {
                var data = (EntityTeleportPacket)packet;
                if (Entitys.ContainsKey(data.EntityId))
                {
                    Transform transform = Entitys[data.EntityId];
                    transform.Position.X = data.X;
                    transform.Position.Y = data.Y;
                    transform.Position.Z = data.Z;
                    transform.Rotation.Yaw = data.Yaw;
                    transform.Rotation.Pitch = data.Pitch;
                    transform.OnGround = data.OnGround;

                    Console.WriteLine($"{transform.Position}");
                }
            }
        }
    }
}
