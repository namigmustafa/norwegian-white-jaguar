using System.Web.Mvc;
using Conditions;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;

namespace NorwegianWhiteJaguar.UI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionViewModelBuilder _transactionViewModelBuilder;

        public TransactionController(ITransactionViewModelBuilder transactionViewModelBuilder)
        {
            Condition.Requires(transactionViewModelBuilder, nameof(transactionViewModelBuilder)).IsNotNull();

            _transactionViewModelBuilder = transactionViewModelBuilder;
        }
        public ActionResult Index(int accountId)
        {
            var accountTransactions = _transactionViewModelBuilder.Build(accountId);

            return View(accountTransactions);
        }
    }
}