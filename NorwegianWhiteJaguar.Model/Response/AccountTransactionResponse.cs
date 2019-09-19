using System.Collections.Generic;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Model.Response
{
    public class AccountTransactionResponse
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
