using NorwegianWhiteJaguar.Model.ViewModel;

namespace NorwegianWhiteJaguar.Interface.ViewModelBuilder
{
    public interface IAccountViewModelBuilder
    {
        CustomerAccountsViewModel Build(int customerId);
    }
}
