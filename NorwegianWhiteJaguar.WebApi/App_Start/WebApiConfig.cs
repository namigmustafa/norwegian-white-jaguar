using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Service.Provider;
using NorwegianWhiteJaguar.WebApi.Common.IOC;
using System.Web.Http;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Service.Services;
using NorwegianWhiteJaguar.Service.ViewModelBuilder;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace NorwegianWhiteJaguar.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IDataProvider, DataProvider>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IBankAccountProvider, BankAccountProvider>();
            container.RegisterType<ICustomerViewModelBuilder, CustomerViewModelBuilder>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<DataProvider>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => DataProvider.Instance));

            config.DependencyResolver = new UnityResolver(container); 

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
