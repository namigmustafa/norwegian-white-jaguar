using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Model.Entities
{
    public class Account : BaseEntity
    {
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public string FriendlyName { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public Customer Customer { get; set; }
    }
}
