using System;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using SMTx.Models;

namespace SMTx.Services
{
    internal class GithubAPI
    {
        private HttpClient _client;

        public GithubAPI()
        {
            _client = new HttpClient();
            _client.Timeout = new System.TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SMT", "1.xx"));
            _client.BaseAddress = new Uri("https://api.github.com");
        }

        public GithubRelease GetLastSMTVersion()
        {   
            HttpResponseMessage response = _client.GetAsync("/repos/slazanger/smt/releases/latest").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                GithubRelease releaseInfo = JsonSerializer.Deserialize<GithubRelease>(responseBody);
                return (releaseInfo);
            }
            return null;
        }
    }
}
