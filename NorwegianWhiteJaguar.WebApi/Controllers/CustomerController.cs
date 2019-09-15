using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace NorwegianWhiteJaguar.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        //private readonly IFileReadWriteProvider _fileReadWriteProvider;
        private readonly ICustomerViewModelBuilder _customerViewModelBuilder;
        public CustomerController(ICustomerViewModelBuilder customerViewModelBuilder)
        {
            //_fileReadWriteProvider = fileReadWriteProvider;
            _customerViewModelBuilder = customerViewModelBuilder;
        }
        public IEnumerable<Customer> Get()
        {
            //string path = HttpContext.Current.Server.MapPath("~/App_Data/customer.txt");

            var customers = _customerViewModelBuilder.Get(1);

            return customers;
        }

        public bool Create()
        {

            var newCustomer = new Customer
            {
                Id = 2,
                Name = "Second",
                Surname = "Third"
            };

            _customerViewModelBuilder.Create(newCustomer);

            

            

            return true;
        }
    }
}
