using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AudioNetworkRock.ExternalAPI
{
    public static class DataFetcher<T>
    {
        public static async Task<T> GetAsync(Uri path)
        { 
            HttpResponseMessage response = await HttpClientSingleton.Instance.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default(T);
        }

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