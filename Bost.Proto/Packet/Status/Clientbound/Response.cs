using Bost.Proto.Model;
using Bost.Proto.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bost.Proto.Packet.Status.Clientbound
{
    public class ResponsePacket : BasePacket
    {
        public override int PacketId => 0x00;

        [MaxLength(32767)] public string JSONResponse;

        public override void Read(byte[] array) => McString.TryParse(ref array, out JSONResponse);
        public override byte[] Write() => McString.ToBytes(JSONResponse);
        public ServerStatus GetStatus() => JsonConvert.DeserializeObject<ServerStatus>(JSONResponse);
    }
}
