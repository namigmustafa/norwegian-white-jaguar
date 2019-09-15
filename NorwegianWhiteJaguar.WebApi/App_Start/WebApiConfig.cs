using NorwegianWhiteJaguar.Interface.Facade;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.Repository;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Service.Facade;
using NorwegianWhiteJaguar.Service.Provider;
using NorwegianWhiteJaguar.Service.Repository;
using NorwegianWhiteJaguar.Service.ViewModelBuilder;
using NorwegianWhiteJaguar.WebApi.Common.IOC;
using System.Web.Http;
using Unity;

namespace NorwegianWhiteJaguar.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            //container.RegisterType<IFileReadWriteProvider, FileReadWriteProvider>();
            //container.RegisterType<IFileReadWriteFacade, FileReadWriteFacade>();
            container.RegisterType<ICustomerViewModelBuilder, CustomerViewModelBuilder>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            config.DependencyResolver = new UnityResolver(container); 

            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
