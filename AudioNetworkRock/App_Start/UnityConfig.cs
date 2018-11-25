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

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}