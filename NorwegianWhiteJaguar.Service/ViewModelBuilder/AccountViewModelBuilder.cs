using NorwegianWhiteJaguar.Interface.ViewModelBuilder;
using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Service.ViewModelBuilder
{
    public class AccountViewModelBuilder : IAccountViewModelBuilder
    {
        public Account Create(int customerId, float balace)
        {
            //check customer if exist
            //generate account

            return new Account();
        }
    }
}
