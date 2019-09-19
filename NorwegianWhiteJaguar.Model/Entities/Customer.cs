using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Model.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
