using System;
using System.Collections.Generic;
using System.Linq;
using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Service.Common.ExceptionHandling;
using NorwegianWhiteJaguar.Service.Common.Helper;

namespace NorwegianWhiteJaguar.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IBankAccountProvider _bankAccountProvider;

        public AccountService(IDataProvider dataProvider, IBankAccountProvider bankAccountProvider)
        {
            Condition.Requires(dataProvider, nameof(dataProvider)).IsNotNull();
            Condition.Requires(bankAccountProvider, nameof(bankAccountProvider)).IsNotNull();

            _dataProvider = dataProvider;
            _bankAccountProvider = bankAccountProvider;
        }

        public void Create(int customerId, Account account)
        {
            Condition.Requires(account, nameof(account)).IsNotNull();
            Condition.Requires(account.Balance).IsNotLessOrEqual(0);
            Condition.Requires(customerId).IsNotLessOrEqual(0);

            var customers = _dataProvider.Get();

            var customer = customers.Find(c => c.Id == customerId);
            
            if(customer == null)
            {
                throw new UseCaseException("Customer not found!");
            }

            if (customer.Accounts == null)
            {
                customer.Accounts = new List<Account>();
            }

            customer.Accounts.Add(new Account
            {
                Balance = account.Balance,
                Id = GetAccountId(),
                Number = _bankAccountProvider.Create(),
                FriendlyName = account.FriendlyName
            });
        }

        public IEnumerable<Transaction> Transactions(int accountId)
        {
            var customers = _dataProvider.Get().Where(c => c.Accounts != null);

            var accounts = customers.SelectMany(c => c.Accounts);

            var transactions = new List<Transaction>();

            foreach (var account in accounts)
            {
                if (account.Id == accountId)
                {
                    transactions = account.Transactions.ToList();

                }
            }

            return transactions;

        }

        private static int GetAccountId()
        {
            var accountId = NumberGenerator.Create(4);

            return Convert.ToInt32(accountId);
        }
    }
}
