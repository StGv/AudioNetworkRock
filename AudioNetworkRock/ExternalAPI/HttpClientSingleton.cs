using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AudioNetworkRock.ExternalAPI
{
    public class HttpClientSingleton
    {
        static HttpClient _client;

        private HttpClientSingleton()
        {
            //_client.DefaultRequestHeaders.Accept.Clear();
            //_client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
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