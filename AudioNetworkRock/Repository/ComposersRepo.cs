using AudioNetworkRock.ExternalAPI;
using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AudioNetworkRock.Repository
{
    public class ComposersRepo : IRepository<Composer>
    {
        public ComposersRepo()
        {
            var path = ConfigurationManager.AppSettings["ComposersWebAPI"];
            Composers = DataFetcher<List<Composer>>.Get(new Uri(path));
        }
        public List<Composer> Composers { get; private set; }

        public IEnumerable<Composer> GetAll()
        {
            return Composers;
        }
    }
}