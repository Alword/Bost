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
            if (hubConnection.State == HubConnectionState.Connected) return;

            hubConnection = new HubConnectionBuilder()
                .WithUrl("")
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
                Console.WriteLine(encodedMsg);
            });
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            await hubConnection.StartAsync();
        }
    }
}
