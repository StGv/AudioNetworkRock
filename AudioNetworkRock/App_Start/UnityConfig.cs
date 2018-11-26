using AudioNetworkRock.MemoryCache;
using AudioNetworkRock.Models;
using AudioNetworkRock.Repository;
using AudioNetworkRock.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace AudioNetworkRock
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRepository<Track>, TracksRepo>();
            container.RegisterType<IRepository<Composer>, ComposersRepo>();
            container.RegisterType<IRockService, RockService>();

            container.RegisterInstance<IMemoryCache>(new MemCacheWrapper(System.Runtime.Caching.MemoryCache.Default));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}