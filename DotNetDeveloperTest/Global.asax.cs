using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DotNetDeveloperTest.IS.DataAccess;
using DotNetDeveloperTest.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace DotNetDeveloperTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<TestDB>(Lifestyle.Scoped);
            container.Register<IOrderItemsService, OrderItemsService>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
