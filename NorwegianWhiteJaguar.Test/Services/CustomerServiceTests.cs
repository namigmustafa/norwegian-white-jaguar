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
    public class CustomerServiceTests
    {
        private Mock<IDataProvider> _dataProviderMock;
        private ICustomerService _customerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dataProviderMock = new Mock<IDataProvider>();

            _customerService = new CustomerService(_dataProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _dataProviderMock.Reset();
        }

        [Test]
        public void Given_When_Build_Should_Return_Customers()
        {
            //arrange
            var customer1 = new Customer
            {
                Id = 1,
                Name = "CustomerName1",
                Surname = "CustomerSurname1"
            };

            var customer2 = new Customer
            {
                Id = 2,
                Name = "CustomerName2",
                Surname = "CustomerSurname2"
            };

            var customers = new List<Customer>
            {
                customer1,
                customer2
            };

            _dataProviderMock.Setup(d => d.Get()).Returns(customers);

            //act
            var expectedCustomers = _customerService.Customers();

            //assert
            Assert.NotNull(expectedCustomers);
            Assert.AreEqual(expectedCustomers.Count(), 2);
        }

        [Test]
        public void Given_When_Accounts_Should_Return_CustomersAccounts()
        {
            //arrange
            var account = new Account
            {
                Id = 1,
                Balance = 50,
                FriendlyName = "FriendlyName",
                Number = "BankAccountNumer"
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

            var customer2 = new Customer
            {
                Id = 2,
                Name = "CustomerName2",
                Surname = "CustomerSurname2"
            };

            var customers = new List<Customer>
            {
                customer1,
                customer2
            };

            _dataProviderMock.Setup(d => d.Get()).Returns(customers);

            //act
            var expectedCustomerAccounts = _customerService.Accounts(customer1.Id);

            var customerAccount = expectedCustomerAccounts.FirstOrDefault();

            //assert
            Assert.NotNull(expectedCustomerAccounts);
            Assert.AreEqual(expectedCustomerAccounts.Count(), 1);
            Assert.AreEqual(customerAccount.Id, account.Id);
            Assert.AreEqual(customerAccount.Number, account.Number);
            Assert.AreEqual(customerAccount.FriendlyName, account.FriendlyName);
            Assert.AreEqual(customerAccount.Balance, account.Balance);
        }

        [Test]
        public void Given_When_Accounts_Should_Fail_CustomerNotFound()
        {
            //arrange
            var account = new Account
            {
                Id = 1,
                Balance = 50,
                FriendlyName = "FriendlyName",
                Number = "BankAccountNumer"
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

            var customer2 = new Customer
            {
                Id = 2,
                Name = "CustomerName2",
                Surname = "CustomerSurname2"
            };

            var customers = new List<Customer>
            {
                customer1,
                customer2
            };

            _dataProviderMock.Setup(d => d.Get()).Returns(customers);

            //act
            //assert
            Assert.Throws<UseCaseException>(() => _customerService.Accounts(6666));
        }
    }
}
