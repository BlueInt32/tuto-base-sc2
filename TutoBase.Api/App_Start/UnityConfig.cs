using Microsoft.Practices.Unity;
using System.Web.Http;
using TutoBase.Infrastructure;
using TutoBase.Core;
using Unity.WebApi;

namespace TutoBase.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
			container.RegisterType<ITutoRepository, TutoRepository>();
        }
    }
}