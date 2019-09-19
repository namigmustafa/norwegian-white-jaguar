using System.Web.Mvc;
using Conditions;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;

namespace NorwegianWhiteJaguar.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerViewModelBuilder _customerViewModelBuilder;
        
        public HomeController(ICustomerViewModelBuilder customerViewModelBuilder)
        {
            Condition.Requires(customerViewModelBuilder, nameof(customerViewModelBuilder)).IsNotNull();

            _customerViewModelBuilder = customerViewModelBuilder;
        }
        public ActionResult Index()
        {
            var customers = _customerViewModelBuilder.Build();
            
            return View(customers);
        }
    }
}