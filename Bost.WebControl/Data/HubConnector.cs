using Bost.Shared;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.WebControl.Data
{
    public class HubConnector
    {
        private HubConnection hubConnection;
        public HubConnector()
        {

        }

        public async Task EnsureConnected(string url)
        {
            if (hubConnection != null && hubConnection.State != HubConnectionState.Disconnected) return;

            hubConnection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            hubConnection.On<ServerStatusData>("ReciveServerStatus", (ServerStatusData) =>
            {
                var encodedMsg = $"{ServerStatusData.CoreName}: {ServerStatusData.Description}";
                Console.WriteLine(encodedMsg);
            });
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }
    }
}
