using AudioNetworkRock.ExternalAPI;
using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AudioNetworkRock.Repository
{
    public class TracksRepo : IRepository<Track>
    {
        public TracksRepo()
        {
            var path = ConfigurationManager.AppSettings["TracksWebAPI"];
            Tracks = AsyncDataFetcher<List<Track>>.GetProductAsync(path).Result;
        }

        public List<Track> Tracks { get; private set; }

        public IEnumerable<Track> GetAll()
        {
            return Tracks;
        }
    }
}