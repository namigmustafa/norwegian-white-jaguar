using System.Collections.Generic;
using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Service.Common.ExceptionHandling;

namespace NorwegianWhiteJaguar.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDataProvider _dataProvider;

        public CustomerService(IDataProvider dataProvider)
        {
            Condition.Requires(dataProvider, nameof(dataProvider)).IsNotNull();

            _dataProvider = dataProvider;
        }

        public IEnumerable<Customer> Customers()
        {
            var customers = _dataProvider.Get();

            return customers;
        }

        public IEnumerable<Account> Accounts(int customerId)
        {
            var customers = _dataProvider.Get();

            var customer = customers.Find(c => c.Id == customerId);

            if (customer == null)
            {
                throw new UseCaseException("Customer not found!");
            }

            return customer.Accounts ?? new List<Account>();
        }
    }
}
