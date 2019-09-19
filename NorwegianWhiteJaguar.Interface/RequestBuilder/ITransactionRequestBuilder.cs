using RestSharp;

namespace NorwegianWhiteJaguar.Interface.RequestBuilder
{
    public interface ITransactionRequestBuilder
    {
        IRestRequest Build(int accountId);
    }
}
