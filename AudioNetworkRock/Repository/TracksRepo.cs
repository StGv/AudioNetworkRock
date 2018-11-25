using AudioNetworkRock.ExternalAPI;
using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AudioNetworkRock.Repository
{
    public class TracksRepo : IRepository<Track>
    {
        public TracksRepo()
        {
            var path = ConfigurationManager.AppSettings["TracksWebAPI"];
            Tracks = DataFetcher<List<Track>>.Get(new Uri(path));
        }

        public List<Track> Tracks { get; private set; }

        public IEnumerable<Track> GetAll()
        {
            return Tracks;
        }
    }
}