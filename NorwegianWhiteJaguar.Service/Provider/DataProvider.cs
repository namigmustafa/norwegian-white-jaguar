using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Model.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NorwegianWhiteJaguar.Service.Provider
{
    [ExcludeFromCodeCoverage]
    public class DataProvider : IDataProvider
    {
        private List<Customer> _customers;
        private DataProvider()
        {
            LoadCustomers();
        }

        public static DataProvider Instance { get; } = new DataProvider();

        public List<Customer> Get()
        {
            var customer = _customers;

            return customer;
        }

        public void LoadCustomers()
        {
            _customers = new List<Customer>
            {
                new Customer
                {
                    Id =1,
                    Name = "Paul",
                    Surname = "Simone"
                },
                new Customer
                {
                    Id = 2,
                    Name = "John",
                    Surname = "Papa"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Marissa",
                    Surname = "Layer"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Will",
                    Surname = "Postm"
                },
                new Customer
                {
                    Id = 5,
                    Name = "Baha",
                    Surname = "Karrati"
                }
            };
        }
    }
}
