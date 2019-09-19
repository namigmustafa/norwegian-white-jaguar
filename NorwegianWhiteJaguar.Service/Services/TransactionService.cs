using System;
using System.Collections.Generic;
using System.Linq;
using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Service.Common.ExceptionHandling;
using NorwegianWhiteJaguar.Service.Common.Helper;

namespace NorwegianWhiteJaguar.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDataProvider _dataProvider;

        public TransactionService(IDataProvider dataProvider)
        {
            Condition.Requires(dataProvider, nameof(dataProvider)).IsNotNull();

            _dataProvider = dataProvider;
        }
        public void Create(decimal amount, int customerId, int accountId)
        {
            Condition.Requires(amount).IsNotLessOrEqual(0);
            Condition.Requires(accountId).IsNotLessOrEqual(0);
            Condition.Requires(customerId).IsNotLessOrEqual(0);

            var customer = _dataProvider.Get().Find(c => c.Id == customerId);

            if (customer == null)
            {
                throw new UseCaseException("Customer not found!");
            }

            if (customer.Accounts == null)
            {
                throw new UseCaseException("Customer does not have any existing account!");
            }

            var accountExist = customer.Accounts.Any(c => c.Id == accountId);

            if (accountExist == false)
            {
                throw  new UseCaseException("Account does not exist!");
            }

            foreach (var customerAccount in customer.Accounts)
            {
                if (customerAccount.Id != accountId) continue;
                if (customerAccount.Transactions == null)
                {
                    customerAccount.Transactions = new List<Transaction>();
                }

                customerAccount.Transactions.Add(new Transaction
                {
                    Id = GetTransactionId(),
                    Amount = amount
                });
            }
        }

        private static int GetTransactionId()
        {
            var accountId = NumberGenerator.Create(4);

            return Convert.ToInt32(accountId);
        }
    }
}
