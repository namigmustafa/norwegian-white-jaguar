using System.Collections.Generic;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Model.ViewModel
{
    public class TransactionViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
