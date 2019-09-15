using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Model.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Account> Accounts { get; set; } // TODO should it be collection? List
    }
}
