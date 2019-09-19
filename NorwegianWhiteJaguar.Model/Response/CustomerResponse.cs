using System.Collections.Generic;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Model.Response
{
    public class CustomerResponse
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
