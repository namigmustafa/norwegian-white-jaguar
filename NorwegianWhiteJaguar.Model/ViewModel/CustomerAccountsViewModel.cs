using System.Collections.Generic;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Model.ViewModel
{
    public class CustomerAccountsViewModel
    {
        public IEnumerable<Account> CustomerAccounts { get; set; }
    }
}
