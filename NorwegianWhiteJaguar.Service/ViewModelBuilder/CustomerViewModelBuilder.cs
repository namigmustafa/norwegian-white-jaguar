using Conditions;
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
        
        public CustomerViewModelBuilder(
            ICustomerRequestBuilder customerRequestBuilder, 
            ICustomerProvider customerProvider)
        {
            Condition.Requires(customerRequestBuilder, nameof(customerRequestBuilder)).IsNotNull();
            Condition.Requires(customerProvider, nameof(customerProvider)).IsNotNull();

            _customerRequestBuilder = customerRequestBuilder;
            _customerProvider = customerProvider;
           
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
    }
}
