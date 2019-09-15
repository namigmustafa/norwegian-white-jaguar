using NorwegianWhiteJaguar.Model.Entities;

namespace NorwegianWhiteJaguar.Interface.ViewModelBuilder
{
    public interface IAccountViewModelBuilder
    {
        Account Create(int customerId, float balace);//TODO should it return Account or AccountDto
    }
}
