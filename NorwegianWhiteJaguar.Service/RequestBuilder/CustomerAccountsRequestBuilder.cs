using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Model.Request;
using RestSharp;

namespace NorwegianWhiteJaguar.Service.RequestBuilder
{
    public class CustomerAccountsRequestBuilder : ICustomerAccountsRequestBuilder
    {
        public IRestRequest Build(int customerId)
        {
            var request = new CustomerAccountsRequest(customerId.ToString());

            return request;
        }
    }
}
