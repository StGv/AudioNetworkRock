using System.Net.Http;
using System.Threading.Tasks;

namespace AudioNetworkRock.ExternalAPI
{
    public static class AsyncDataFetcher<T>
    {
        public static async Task<T> GetProductAsync(string path)
        {
            HttpResponseMessage response = await HttpClientSingleton.Instance.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            return default(T);
        }
    }
}