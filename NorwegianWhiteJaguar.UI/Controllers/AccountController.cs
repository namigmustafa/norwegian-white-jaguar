using System.Web.Mvc;
using Conditions;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;

namespace NorwegianWhiteJaguar.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountViewModelBuilder _accountViewModelBuilder;

        public AccountController(IAccountViewModelBuilder accountViewModelBuilder)
        {
            Condition.Requires(accountViewModelBuilder, nameof(accountViewModelBuilder)).IsNotNull();

            _accountViewModelBuilder = accountViewModelBuilder;
        }
        
        public ActionResult Index(int customerId)
        {
            var customerAccount = _accountViewModelBuilder.Build(customerId);

            return View(customerAccount);
        }
    }
}