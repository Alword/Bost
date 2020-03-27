using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.Client
{
    public class Effect : Command
    {
        public override string Execute(byte[] array)
        {
            return "Effect!";
        }
    }
}
