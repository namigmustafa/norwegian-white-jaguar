using System.Collections.Generic;
using System.Linq;
using Moq;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Service.Common.ExceptionHandling;
using NorwegianWhiteJaguar.Service.Services;
using NUnit.Framework;

namespace NorwegianWhiteJaguar.Test.Services
{
    public class AccountServiceTests
    {
        private Mock<IDataProvider> _dataProviderMock;
        private Mock<IBankAccountProvider> _bankAccountProviderMock;
        private IAccountService _accountService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dataProviderMock = new Mock<IDataProvider>();
            _bankAccountProviderMock = new Mock<IBankAccountProvider>();

            _accountService = new AccountService(_dataProviderMock.Object, _bankAccountProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _dataProviderMock.Reset();
        }

        [Test]
        public void Given_Params_When_Create_Should_Create_NewAccount()
        {
            //arrange
            var account = new Account
            {
                Id = 1,
                Balance = 500,
                FriendlyName = "FriendlyName",
                Number = "NL22TATA2356475236540"
            };

            var customer1 = new Customer
            {
                Id = 1,
                Name = "CustomerName1",
                Surname = "CustomerSurname1"
            };

            var customers = new List<Customer>
            {
                customer1
            };

            _dataProviderMock.Setup(d => d.Get()).Returns(customers);
            _bankAccountProviderMock.Setup(b => b.Create()).Returns(account.Number);

            //act
             _accountService.Create(customer1.Id, account);

            //assert
            var expectedCustomerAccount = customer1.Accounts.FirstOrDefault();

            Assert.NotNull(customer1.Accounts);
            Assert.AreEqual(customer1.Accounts.Count, 1);
            Assert.AreEqual(expectedCustomerAccount.Balance, account.Balance);
            Assert.AreEqual(expectedCustomerAccount.FriendlyName, account.FriendlyName);
            Assert.AreEqual(expectedCustomerAccount.Number, account.Number);
        }

        [Test]
        public void Given_Params_When_Create_Should_Fail()
        {
            //arrange
            var account = new Account
            {
                Id = 1,
                Balance = 500,
                FriendlyName = "FriendlyName",
                Number = "NL22TATA2356475236540"
            };

            var customer1 = new Customer
            {
                Id = 1,
                Name = "CustomerName1",
                Surname = "CustomerSurname1"
            };

            var customers = new List<Customer>
            {
                customer1
            };

            _dataProviderMock.Setup(d => d.Get()).Returns(customers);
           
            //act
            //assert
             Assert.Throws<UseCaseException>(() => _accountService.Create(5, account));
        }

        [Test]
        public void Given_Params_When_Transactions_Should_Return_AccountTransaction()
        {
            //arrange
            var transaction1 = new Transaction
            {
                Id = 1,
                Amount = 100
            };

            var account = new Account
            {
                Id = 1,
                Balance = 500,
                FriendlyName = "FriendlyName",
                Number = "NL22TATA2356475236540",
                Transactions = new List<Transaction>
                {
                    transaction1
                }
            };

            var customer1 = new Customer
            {
                Id = 1,
                Name = "CustomerName1",
                Surname = "CustomerSurname1",
                Accounts = new List<Account>
                {
                    account
                }
            };

            var customers = new List<Customer>
            {
                customer1
            };

            _dataProviderMock.Setup(d => d.Get()).Returns(customers);
            
            //act
            var transactions = _accountService.Transactions(account.Id);

            //assert
            var expectedTransactions = transactions.FirstOrDefault();

            Assert.NotNull(transactions);
            Assert.AreEqual(transactions.Count(), 1);
            Assert.AreEqual(expectedTransactions.Id, transaction1.Id);
            Assert.AreEqual(expectedTransactions.Amount, transaction1.Amount);
        }
    }
}
