using System.Collections.Generic;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Interface.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Customers();
        IEnumerable<Account> Accounts(int customerId);
    }
}
