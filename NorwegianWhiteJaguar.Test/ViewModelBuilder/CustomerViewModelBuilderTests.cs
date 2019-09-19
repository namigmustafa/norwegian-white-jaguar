using System.Collections.Generic;
using System.Linq;
using NorwegianWhiteJaguar.Interface.Provider;
using Moq;
using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Interface.Services;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;
using NorwegianWhiteJaguar.Model.Request;
using NorwegianWhiteJaguar.Model.Response;
using NorwegianWhiteJaguar.Service.ViewModelBuilder;
using NUnit.Framework;

namespace NorwegianWhiteJaguar.Test.ViewModelBuilder
{
    public class CustomerViewModelBuilderTests
    {
        private Mock<ICustomerRequestBuilder> _customerRequestBuilderMock;
        private Mock<ICustomerProvider> _customerProviderMock;

        private ICustomerViewModelBuilder _customerViewModelBuilder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _customerRequestBuilderMock = new Mock<ICustomerRequestBuilder>();
            _customerProviderMock = new Mock<ICustomerProvider>();

            _customerViewModelBuilder = new CustomerViewModelBuilder(_customerRequestBuilderMock.Object, _customerProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _customerRequestBuilderMock.Reset();
            _customerProviderMock.Reset();
        }

        [Test]
        public void Given_When_Build_Should_Build_CustomerViewModel()
        {
            //arrange
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

            var customerResponse = new CustomerResponse
            {
                Customers = customers
            };


            var customerRequest = new CustomerRequest();

            _customerRequestBuilderMock.Setup(c => c.Build()).Returns(customerRequest);

            _customerProviderMock.Setup(c => c.Execute(customerRequest)).Returns(customerResponse);
            
            //act
            var expectedCustomerViewModel = _customerViewModelBuilder.Build();

            //assert
            var expectedCustomer = expectedCustomerViewModel.Customers.FirstOrDefault();

            Assert.NotNull(expectedCustomerViewModel);
            Assert.AreEqual(expectedCustomerViewModel.Customers.Count(), 1);
            Assert.AreEqual(expectedCustomer.Name, customer1.Name);
            Assert.AreEqual(expectedCustomer.Surname, customer1.Surname);

        }
    }
}
