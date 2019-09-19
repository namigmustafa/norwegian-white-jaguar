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
    public class TransactionViewModelBuilderTests
    {
        private Mock<ITransactionRequestBuilder> _transactionRequestBuilderMock;
        private Mock<ITransactionProvider> _transactionProviderMock;

        private ITransactionViewModelBuilder _transactionViewModelBuilder;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _transactionRequestBuilderMock = new Mock<ITransactionRequestBuilder>();
            _transactionProviderMock = new Mock<ITransactionProvider>();

            _transactionViewModelBuilder = new TransactionViewModelBuilder(_transactionRequestBuilderMock.Object, _transactionProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _transactionRequestBuilderMock.Reset();
            _transactionProviderMock.Reset();
        }

        [Test]
        public void Given_When_Build_Should_Build_CustomerAccountViewModel()
        {
            //arrange
            var transaction = new Transaction
            {
                Id = 1,
                Amount = 50
            };

            var accountTransactionResponse = new AccountTransactionResponse
            {
                Transactions = new List<Transaction>
                {
                    transaction
                }
            };

            var transactionRequest = new TransactionRequest(1);

            _transactionRequestBuilderMock.Setup(c => c.Build(1)).Returns(transactionRequest);

            _transactionProviderMock.Setup(c => c.Execute(transactionRequest)).Returns(accountTransactionResponse);

            //act
            var expectedAccountTransactionViewModel = _transactionViewModelBuilder.Build(1);

            //assert
            var expectedAccountTransaction = expectedAccountTransactionViewModel.Transactions.FirstOrDefault();

            Assert.NotNull(expectedAccountTransactionViewModel);
            Assert.AreEqual(expectedAccountTransactionViewModel.Transactions.Count(), 1);
            Assert.AreEqual(expectedAccountTransaction.Id, transaction.Id);
            Assert.AreEqual(expectedAccountTransaction.Amount, transaction.Amount);
        }
    }
}
