using System.Collections.Generic;
using System.Linq;
using Moq;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Model.Request;
using NorwegianWhiteJaguar.Model.Response;
using NorwegianWhiteJaguar.Service.ViewModelBuilder;
using NUnit.Framework;

namespace NorwegianWhiteJaguar.Test.ViewModelBuilder
{
    public class AccountViewModelBuilderTests
    {
        private Mock<ICustomerAccountsRequestBuilder> _customerAccountsRequestBuilderMock;
        private Mock<ICustomerAccountsProvider> _customerAccountsProviderMock;

        private IAccountViewModelBuilder _accountViewModelBuilder;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _customerAccountsRequestBuilderMock = new Mock<ICustomerAccountsRequestBuilder>();
            _customerAccountsProviderMock = new Mock<ICustomerAccountsProvider>();

            _accountViewModelBuilder = new AccountViewModelBuilder(_customerAccountsRequestBuilderMock.Object, _customerAccountsProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _customerAccountsRequestBuilderMock.Reset();
            _customerAccountsProviderMock.Reset();
        }

        [Test]
        public void Given_When_Build_Should_Build_CustomerAccountViewModel()
        {
            //arrange
            var account1 = new Account
            {
                Id = 1,
                Balance = 50,
                Number = "Number",
                FriendlyName = "FriendlyName"
            };

            var customerAccountsResponse = new CustomerAccountsResponse
            {
               CustomerAccounts = new List<Account>
               {
                   account1
               }
            };
            
            var customerAccountsRequest = new CustomerAccountsRequest("1");

            _customerAccountsRequestBuilderMock.Setup(c => c.Build(1)).Returns(customerAccountsRequest);

            _customerAccountsProviderMock.Setup(c => c.Execute(customerAccountsRequest)).Returns(customerAccountsResponse);

            //act
            var expectedCustomerAccouterViewModel = _accountViewModelBuilder.Build(1);

            //assert
            var expectedCustomerAccount = expectedCustomerAccouterViewModel.CustomerAccounts.FirstOrDefault();

            Assert.NotNull(expectedCustomerAccouterViewModel);
            Assert.AreEqual(expectedCustomerAccouterViewModel.CustomerAccounts.Count(), 1);
            Assert.AreEqual(expectedCustomerAccount.Id, account1.Id);
            Assert.AreEqual(expectedCustomerAccount.Balance, account1.Balance);
            Assert.AreEqual(expectedCustomerAccount.FriendlyName, account1.FriendlyName);
            Assert.AreEqual(expectedCustomerAccount.Number, account1.Number);
        }
    }
}
