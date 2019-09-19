using System.Collections.Generic;
using System.Linq;
using Moq;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Service.Common.ExceptionHandling;
using NorwegianWhiteJaguar.Service.Services;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace NorwegianWhiteJaguar.Test.Services
{
    public class TransactionServiceTests
    {
        private Mock<IDataProvider> _dataProviderMock;
        private ITransactionService _transactionService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dataProviderMock = new Mock<IDataProvider>();
            _transactionService = new TransactionService(_dataProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _dataProviderMock.Reset();
        }

        [Test]
        public void Given_Params_When_Create_Should_Create_NewTransaction()
        {
            //arrange
            const int transactionAmount = 50;

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
            _transactionService.Create(transactionAmount, customer1.Id, account.Id);

            //assert
            NotNull(account.Transactions);
            AreEqual(account.Transactions.Count, 1);
            AreEqual(account.Transactions.FirstOrDefault().Amount, transactionAmount);
        }

        [Test]
        public void Given_Params_When_Create_Should_CheckCustomerAccount_ShouldFail()
        {
            //arrange
            const int transactionAmount = 50;
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
            Assert.Throws<UseCaseException>(() => _transactionService.Create(transactionAmount, customer1.Id, 1));
        }

        [Test]
        public void Given_Params_When_Create_Should_CheckAccountExist_ShouldFail()
        {
            //arrange
            const int transactionAmount = 50;

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
            //assert
            Assert.Throws<UseCaseException>(() => _transactionService.Create(transactionAmount, customer1.Id, 2));
        }

        [Test]
        public void Given_Params_When_Create_Should_CheckCustomerExist_ShouldFail()
        {
            //arrange
            const int transactionAmount = 50;

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
            //assert
            Assert.Throws<UseCaseException>(() => _transactionService.Create(transactionAmount, 1111, 2));
        }
    }
}
