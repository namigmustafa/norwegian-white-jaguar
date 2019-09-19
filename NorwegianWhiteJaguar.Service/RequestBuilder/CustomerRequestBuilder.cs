using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Model.Request;
using RestSharp;

namespace NorwegianWhiteJaguar.Service.RequestBuilder
{
    public class CustomerRequestBuilder : ICustomerRequestBuilder
    {
        public IRestRequest Build()
        {
            var request = new CustomerRequest();

            return request;
        }
    }
}
