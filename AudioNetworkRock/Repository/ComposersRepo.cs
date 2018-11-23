using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AudioNetworkRock.ExternalAPI;
using System.Configuration;

namespace AudioNetworkRock.Repository
{
    public class ComposersRepo : IRepository<Composer>
    {
        public ComposersRepo()
        {
            var path = ConfigurationManager.AppSettings["ComposersWebAPI"];
            Composers = AsyncDataFetcher<List<Composer>>.GetProductAsync(path).Result;
        }
        public List<Composer> Composers { get; private set; }

        public IEnumerable<Composer> GetAll()
        {
            return Composers;
        }
    }
}