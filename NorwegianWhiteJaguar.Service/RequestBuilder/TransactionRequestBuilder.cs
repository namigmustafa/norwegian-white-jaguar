using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Model.Request;
using RestSharp;

namespace NorwegianWhiteJaguar.Service.RequestBuilder
{
    public class TransactionRequestBuilder : ITransactionRequestBuilder
    {
        public IRestRequest Build(int accountId)
        {
            var request = new TransactionRequest(accountId);

            return request;
        }
    }
}
