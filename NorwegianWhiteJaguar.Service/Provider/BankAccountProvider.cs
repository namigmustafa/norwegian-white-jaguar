using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NorwegianWhiteJaguar.Interface.Provider;
using NorwegianWhiteJaguar.Service.Common.Constants;
using NorwegianWhiteJaguar.Service.Common.Helper;

namespace NorwegianWhiteJaguar.Service.Provider
{
    [ExcludeFromCodeCoverage]
    public class BankAccountProvider : IBankAccountProvider
    {
        public string Create()
        {
            var generatedNumbers = NumberGenerator.Create(10);

            var generatedBankAccount = Constants.BankAccountPrefix + new string(generatedNumbers.ToArray());

            return generatedBankAccount;
        }
    }
}
