using NorwegianWhiteJaguar.Model.Response;
using RestSharp;

namespace NorwegianWhiteJaguar.Interface.Provider
{
    public interface ITransactionProvider
    {
        AccountTransactionResponse Execute(IRestRequest request);
    }
}
