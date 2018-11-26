using AudioNetworkRock.ExternalAPI;
using AudioNetworkRock.MemoryCache;
using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AudioNetworkRock.Repository
{
    public class TracksRepo : IRepository<Track>
    {
        const string CACHE_KEY = "tracks";
        const string WEB_URI_CONFIG_KEY = "TracksWebAPI";

        IMemoryCache _cache;
        public TracksRepo(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IEnumerable<Track> GetAll()
        {
            if (_cache.Contains(CACHE_KEY))
            {
                return _cache.Get(CACHE_KEY) as List<Track>;
            }

            var tracks = GetDatafromWeb();
            _cache.Add(CACHE_KEY, tracks);

            return tracks;
        }

        private static List<Track> GetDatafromWeb()
        {
            var path = ConfigurationManager.AppSettings[WEB_URI_CONFIG_KEY];
            return DataFetcher<List<Track>>.Get(new Uri(path));
        }
    }
}