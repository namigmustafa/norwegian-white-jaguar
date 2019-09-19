using System.Collections.Generic;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Interface.Services
{
    public interface IAccountService
    {
        void Create(int customerId, Account account);
        IEnumerable<Transaction> Transactions(int accountId);
    }
}
