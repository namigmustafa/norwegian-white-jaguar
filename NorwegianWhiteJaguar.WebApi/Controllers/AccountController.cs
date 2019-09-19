using System.Linq;
using NorwegianWhiteJaguar.Model.Entities;
using System.Web.Http;
using Conditions;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Model.Response;

namespace NorwegianWhiteJaguar.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            Condition.Requires(accountService, nameof(accountService)).IsNotNull();

            _accountService = accountService;
        }

        public bool Create(int customerId, Account account)
        {
            _accountService.Create(customerId, account);

            return true;
        }

        [HttpGet]
        public AccountTransactionResponse ListAccountTransaction(int accountId)
        {
            var transactions = _accountService.Transactions(accountId);

            var accountTransactionResponse = new AccountTransactionResponse
            {
                Transactions = transactions.ToList()
            };

            return accountTransactionResponse;
        }
    }
}
