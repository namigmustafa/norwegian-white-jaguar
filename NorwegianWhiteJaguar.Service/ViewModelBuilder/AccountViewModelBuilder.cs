using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.ViewModel;

namespace NorwegianWhiteJaguar.Service.ViewModelBuilder
{
    public class AccountViewModelBuilder : IAccountViewModelBuilder
    {
        private readonly ICustomerAccountsRequestBuilder _customerAccountsRequestBuilder;
        private readonly ICustomerAccountsProvider _customerAccountsProvider;

        public AccountViewModelBuilder(
            ICustomerAccountsRequestBuilder customerAccountsRequestBuilder, 
            ICustomerAccountsProvider customerAccountsProvider)
        {
            Condition.Requires(customerAccountsRequestBuilder, nameof(customerAccountsRequestBuilder)).IsNotNull();
            Condition.Requires(customerAccountsProvider, nameof(customerAccountsProvider)).IsNotNull();

            _customerAccountsRequestBuilder = customerAccountsRequestBuilder;
            _customerAccountsProvider = customerAccountsProvider;
        }
        public CustomerAccountsViewModel Build(int customerId)
        {
            var request = _customerAccountsRequestBuilder.Build(customerId);

            var customerApiCallResult = _customerAccountsProvider.Execute(request);

            return new CustomerAccountsViewModel
            {
                CustomerAccounts = customerApiCallResult.CustomerAccounts
            };
        }
    }
}
