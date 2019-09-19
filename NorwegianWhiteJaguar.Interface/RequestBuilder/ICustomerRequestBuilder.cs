using RestSharp;

namespace NorwegianWhiteJaguar.Interface.RequestBuilder
{
    public interface ICustomerRequestBuilder
    {
        IRestRequest Build();
    }
}
