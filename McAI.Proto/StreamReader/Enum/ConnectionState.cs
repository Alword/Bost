using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader.Enum
{
    public enum ConnectionState
    {
        Handshaking,
        Status,
        Login,
        Play
    }
}
