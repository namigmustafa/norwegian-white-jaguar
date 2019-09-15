using NorwegianWhiteJaguar.Model.Entities;
using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Interface.ViewModelBuilder
{
    public interface ICustomerViewModelBuilder
    {
        IEnumerable<Customer> Get(int customerId);//TODO should it be Get and in this method? what about Manager?
        void Create(Customer customer);
    }
}
