using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.ViewModel;

namespace NorwegianWhiteJaguar.Service.ViewModelBuilder
{
    public class TransactionViewModelBuilder : ITransactionViewModelBuilder
    {
        private readonly ITransactionRequestBuilder _transactionRequestBuilder;
        private readonly ITransactionProvider _transactionProvider;

        public TransactionViewModelBuilder(
            ITransactionRequestBuilder transactionRequestBuilder,
            ITransactionProvider transactionProvider)
        {
            Condition.Requires(transactionRequestBuilder, nameof(transactionRequestBuilder)).IsNotNull();
            Condition.Requires(transactionProvider, nameof(transactionProvider)).IsNotNull();

            _transactionRequestBuilder = transactionRequestBuilder;
            _transactionProvider = transactionProvider;
        }

        public TransactionViewModel Build(int accountId)
        {
            var request = _transactionRequestBuilder.Build(accountId);

            var accountTransaction = _transactionProvider.Execute(request);

            var transactionViewModel = new TransactionViewModel
            {
                Transactions = accountTransaction.Transactions
            };

            return transactionViewModel;
        }
    }
}
