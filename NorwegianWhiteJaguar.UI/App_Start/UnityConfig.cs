using System.Configuration;
using System.Web.Mvc;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Service.Common;
using NorwegianWhiteJaguar.Service.Provider;
using NorwegianWhiteJaguar.Service.RequestBuilder;
using NorwegianWhiteJaguar.Service.ViewModelBuilder;
using RestSharp;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace NorwegianWhiteJaguar.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICustomerRequestBuilder, CustomerRequestBuilder>();
            container.RegisterType<ICustomerProvider, CustomerProvider>();
            container.RegisterType<IGatewaySettings, GatewaySettings>();
            container.RegisterType<ICustomerViewModelBuilder, CustomerViewModelBuilder>();
            container.RegisterType<ICustomerAccountsRequestBuilder, CustomerAccountsRequestBuilder>();
            container.RegisterType<ICustomerAccountsProvider, CustomerAccountsProvider>();
            container.RegisterType<ITransactionViewModelBuilder, TransactionViewModelBuilder>();
            container.RegisterType<ITransactionRequestBuilder, TransactionRequestBuilder>();
            container.RegisterType<ITransactionProvider, TransactionProvider>();
            container.RegisterType<IAccountViewModelBuilder, AccountViewModelBuilder>();

            container.RegisterType<IRestClient, RestClient>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor());

            var settings = ConfigurationManager.AppSettings;
            var baseUri = settings[GatewaySettingsConst.NorwegianWhiteJaguarApiBaseUri];
            
            container.RegisterType<IGatewaySettings, GatewaySettings>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(baseUri));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}