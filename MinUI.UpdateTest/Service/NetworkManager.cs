using MinUI.UpdateTest.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinUI.UpdateTest.Service
{
    public class NetworkManager
    {
        private readonly string _serverUrl = "http://localhost:5001";

        private HttpClient _client;
        public NetworkManager() 
        {
            InitVariables();
        }

        private void InitVariables()
        {
            _client = new HttpClient();
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
