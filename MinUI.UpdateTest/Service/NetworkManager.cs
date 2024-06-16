using MinUI.UpdateTest.Model.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinUI.UpdateTest.Service
{
    public class NetworkManager
    {
        private readonly string _serverUrl = "http://localhost:5001";
        private ClientWebSocket _webSocket;
        private HttpClient _client;
        public NetworkManager() 
        {
            InitVariables();
            InitWebSocket();
        }

        private void InitVariables()
        {
            _client = new HttpClient();
            _webSocket = new ClientWebSocket();
        }

        private async void InitWebSocket()
        {
            Uri serverUri = new Uri("ws://localhost:5002");
            await _webSocket.ConnectAsync(serverUri, CancellationToken.None);
            
        }

        private ArraySegment<byte> StringToByte(string str)
        {
            return new ArraySegment<byte>(Encoding.UTF8.GetBytes(str));
        }

        public async Task SendWebSocketMessage(string message)
        {
            await _webSocket.SendAsync(StringToByte(message),WebSocketMessageType.Text,true,CancellationToken.None);
        }

        public async Task DownloadNewVersion(DownloadLogger logger)
        {
            var recieved = 0;
            var total = -1;
            await SendWebSocketMessage("download");
            var buffer = new ArraySegment<byte>(new byte[1024]);
            for(; total != recieved; )
            {
                var resp = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);
                var str = Encoding.UTF8.GetString(buffer.Array, 0, resp.Count);
                var data = JsonSerializer.Deserialize<DownloadResponse>(str);
                if (data.Message != null)
                {
                    total = int.Parse(data.Message);
                    continue;
                }
                if (data.FileName != null)
                {
                    logger.Log(data.FileName + " downloaded");
                    recieved++;
                }
            }
        }

        public async Task<VersionResponse> GetNewVersion()
        {
            var resp = await _client.GetAsync(_serverUrl+"/version");
            try
            {

                var data = await resp.Content.ReadFromJsonAsync<VersionResponse>();
                return data;
            }
            catch (Exception ex) 
            {
                throw new Exception("get version failed");
            }
        }
    }
}
