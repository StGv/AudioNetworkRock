using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AudioNetworkRock.ExternalAPI
{
    public class HttpClientSingleton
    {
        private static HttpClient _client;

        public HttpClientSingleton()
        {
            _client.Timeout = new TimeSpan(0, 0, 1);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient Instance
        {
            get
            {
                if (_client == null)
                    _client = new HttpClient();
                return _client;
            }
        }
    }
}