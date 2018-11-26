using AudioNetworkRock.ExternalAPI;
using AudioNetworkRock.MemoryCache;
using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AudioNetworkRock.Repository
{
    public class ComposersRepo : IRepository<Composer>
    {
        const string CACHE_KEY = "composers";
        const string WEB_URI_CONFIG_KEY = "ComposersWebAPI";

        IMemoryCache _cache;

        public ComposersRepo(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IEnumerable<Composer> GetAll()
        {
            if (_cache.Contains(CACHE_KEY))
            {
                return _cache.Get(CACHE_KEY) as List<Composer>;
            }

            var composers = GetDataFromWeb();
            _cache.Add(CACHE_KEY, composers);

            return composers;
        }

        private static List<Composer> GetDataFromWeb()
        {
            var path = ConfigurationManager.AppSettings[WEB_URI_CONFIG_KEY];
            return DataFetcher<List<Composer>>.Get(new Uri(path));
        }

    }
}