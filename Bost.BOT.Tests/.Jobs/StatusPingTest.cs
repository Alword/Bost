using Bost.Agent.Jobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bost.Agent.Tests.Jobs
{
    public class StatusPingTest
    {
        [Fact]
        public async Task TestServer()
        {
            StatusPing status = new StatusPing("178.63.45.3", 25852);
            var serverStatus = await status.RequestStatus();
        }
    }
}
