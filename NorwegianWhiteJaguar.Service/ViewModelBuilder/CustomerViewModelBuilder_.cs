using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Interface.RequestBuilder;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.ViewModel;

namespace NorwegianWhiteJaguar.Service.ViewModelBuilder
{
    public class CustomerViewModelBuilder : ICustomerViewModelBuilder
    {
        private readonly ICustomerRequestBuilder _customerRequestBuilder;
        private readonly ICustomerProvider _customerProvider;
        private readonly ICustomerAccountsRequestBuilder _customerAccountsRequestBuilder;
        private readonly ICustomerAccountsProvider _customerAccountsProvider;

        public CustomerViewModelBuilder(
            ICustomerRequestBuilder customerRequestBuilder, 
            ICustomerProvider customerProvider,
            ICustomerAccountsRequestBuilder customerAccountsRequestBuilder,
            ICustomerAccountsProvider customerAccountsProvider)
        {
            _customerRequestBuilder = customerRequestBuilder;
            _customerProvider = customerProvider;
            _customerAccountsRequestBuilder = customerAccountsRequestBuilder;
            _customerAccountsProvider = customerAccountsProvider;
        }
        public CustomerViewModel Build()
        {
            var request = _customerRequestBuilder.Build();

            var customerApiCallResult = _customerProvider.Execute(request);

            var customerViewModelBuilder = new CustomerViewModel
            {
                Customers = customerApiCallResult.Customers
            };

            return customerViewModelBuilder;
        }

        public CustomerAccountsViewModel BuildAccountsViewModel(int customerId)
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
