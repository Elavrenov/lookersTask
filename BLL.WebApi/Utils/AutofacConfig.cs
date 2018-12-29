using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DAL.CosmosDb;
using DAL.CosmosDb.Initializer;
using DAL.Interfaces.Interfaces;

namespace BLL.WebApi.Utils
{
    public class AutofacConfig
    {
        public static async Task Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            await SetUpRegistration(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static async Task SetUpRegistration(ContainerBuilder builder)
        {
            await CosmosContext.RegisterCosmosContextAsync();
            builder.RegisterType<CosmosRepository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();
        }
    }
}