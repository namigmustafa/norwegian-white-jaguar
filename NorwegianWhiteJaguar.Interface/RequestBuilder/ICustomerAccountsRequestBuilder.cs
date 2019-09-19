using RestSharp;

namespace NorwegianWhiteJaguar.Interface.RequestBuilder
{
    public interface ICustomerAccountsRequestBuilder
    {
        IRestRequest Build(int customerId);
    }
}
