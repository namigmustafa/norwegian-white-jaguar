using NorwegianWhiteJaguar.Model.Response;
using RestSharp;

namespace NorwegianWhiteJaguar.Interface.Provider
{
    public interface ICustomerAccountsProvider
    {
        CustomerAccountsResponse Execute(IRestRequest request);
    }
}
