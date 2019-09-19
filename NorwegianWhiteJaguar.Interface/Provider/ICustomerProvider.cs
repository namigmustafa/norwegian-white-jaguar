using NorwegianWhiteJaguar.Model.Response;
using RestSharp;

namespace NorwegianWhiteJaguar.Interface.Provider
{
    public interface ICustomerProvider
    {
        CustomerResponse Execute(IRestRequest request);
    }
}
