using System.Linq;
using System.Web.Http;
using Conditions;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Model.Response;

namespace NorwegianWhiteJaguar.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        
        public CustomerController(ICustomerService customerService)
        {
            Condition.Requires(customerService, nameof(customerService)).IsNotNull();

            _customerService = customerService;
        }

        [HttpGet]
        public CustomerResponse ListCustomers()
        {
            var customers = _customerService.Customers();

            var customerResponse = new CustomerResponse
            {
                Customers = customers
            };

            return customerResponse;
        }

        [HttpGet]
        public CustomerAccountsResponse ListCustomerAccounts(int customerId)
        {
            var customerAccounts = _customerService.Accounts(customerId);

            var customerAccountsResponse = new CustomerAccountsResponse
            {
                CustomerAccounts = customerAccounts.ToList()
            };

            return customerAccountsResponse;
        }
    }
}
