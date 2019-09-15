using NorwegianWhiteJaguar.Interface.Repository;
using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;
using System;
using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Service.ViewModelBuilder
{
    public class CustomerViewModelBuilder : ICustomerViewModelBuilder
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerViewModelBuilder(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(Customer customer)
        {
            _customerRepository.Insert(customer);
        }

        public IEnumerable<Customer> Get(int customerId)//TODO should it return Customer or CustomerDto or something like that
        {
            var customers = _customerRepository.GetAll();

            return customers;
        }
    }
}
