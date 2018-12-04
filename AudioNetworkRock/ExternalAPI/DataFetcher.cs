using System;
using System.Net.Http;

namespace AudioNetworkRock.ExternalAPI
{
    public static class DataFetcher<T>
    {
        public static T Get(Uri url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = HttpClientSingleton.Instance.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<T>().Result;

            return default(T);
        }


    }
}