using MinUI.DownloadTest.Model.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinUI.DownloadTest.Service
{
    public class NetworkManager
    {
        private readonly string _serverUrl = "http://localhost:5001";
        private ClientWebSocket _webSocket;
        private HttpClient _client;
        private Dictionary<string, MemoryStream> _buffer;

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

        private void CreateDirectory(string path)
        {
            try
            {
                // 디렉토리 생성
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("디렉토리가 성공적으로 생성되었습니다: " + path);
                }
                else
                {
                    Console.WriteLine("디렉토리가 이미 존재합니다: " + path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("디렉토리 생성 중 오류 발생: " + e.Message);
            }
        }

        public async Task DownloadNewVersion(DownloadLogger logger, string path)
        {
            _buffer = new Dictionary<string, MemoryStream>();
            await SendWebSocketMessage("download");
            var buffer = new ArraySegment<byte>(new byte[8192*2]);
            var fileCount = 0;
            var total = -1;
            CreateDirectory(Path.Combine(path,"1.0"));
            while (true) 
            {
                var resp = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);
                var str = Encoding.UTF8.GetString(buffer.Array, 0, resp.Count);
                var data = JsonSerializer.Deserialize<DownloadResponse>(str);
                if (data.Message != null)
                {
                    if(data.Message == "eof")
                    {
                        var stream = _buffer[data.FileName];
                        string filePath = Path.Combine(path, "1.0", data.FileName);
                        await File.WriteAllBytesAsync(filePath, stream.ToArray());
                        _buffer.Remove(data.FileName);
                        fileCount++;
                    }
                    else if(data.Message.Contains("file count"))
                    {
                        var a = data.Message.Split(":")[1];
                        total = int.Parse(a);
                    }
                } 
                if (data.FileData != null)
                {
                    var stream = new MemoryStream();
                    byte[] fileBytes = Convert.FromBase64String(data.FileData);

                    if (!_buffer.ContainsKey(data.FileName))
                    {
                        _buffer[data.FileName] = stream;
                    }
                    else
                    {
                        stream = _buffer[data.FileName];
                    }
                    stream.Write(fileBytes, 0, fileBytes.Length);
                }

                if (data.Error != null)
                {
                    
                }
                if(total == fileCount)
                {
                    break;
                }
            }
        }

        private async Task StoreFile(DownloadResponse data, string path)
        {
            if (data.FileData != null)
            {
                byte[] fileBytes = Convert.FromBase64String(data.FileData);
                string filePath = Path.Combine(path, data.FileName);
                await File.WriteAllBytesAsync(filePath, fileBytes);
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
