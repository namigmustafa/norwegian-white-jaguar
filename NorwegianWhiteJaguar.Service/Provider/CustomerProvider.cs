using System;
using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Model.Response;
using RestSharp;

namespace NorwegianWhiteJaguar.Service.Provider
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly IRestClient _restClient;
        private readonly IGatewaySettings _gatewaySettings;

        public CustomerProvider(IRestClient restClient, IGatewaySettings gatewaySettings)
        {
            Condition.Requires(restClient, nameof(restClient)).IsNotNull();
            Condition.Requires(gatewaySettings, nameof(gatewaySettings)).IsNotNull();

            _restClient = restClient;
            _gatewaySettings = gatewaySettings;
        }
        public CustomerResponse Execute(IRestRequest request)
        {
            Condition.Requires(request, nameof(request)).IsNotNull();
            Condition.Requires(_gatewaySettings.BaseUri, nameof(_gatewaySettings.BaseUri)).IsNotNull();
            
            _restClient.BaseUrl = new Uri(_gatewaySettings.BaseUri + "customer/listCustomers");

            var result = _restClient.Execute<CustomerResponse>(request);

            return result.Data;
        }
    }
}
