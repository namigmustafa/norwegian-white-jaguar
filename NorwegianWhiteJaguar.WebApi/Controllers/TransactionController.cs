using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using System.Web.Http;
using Conditions;

namespace NorwegianWhiteJaguar.WebApi.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            Condition.Requires(transactionService, nameof(transactionService)).IsNotNull();

            _transactionService = transactionService;
        }
        public void Create(decimal amount, int customerId, int accountId)
        {
            _transactionService.Create(amount, customerId, accountId);
        }
    }
}
