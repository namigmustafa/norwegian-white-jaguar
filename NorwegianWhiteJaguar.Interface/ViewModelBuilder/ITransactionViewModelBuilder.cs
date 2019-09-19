using NorwegianWhiteJaguar.Model.ViewModel;

namespace NorwegianWhiteJaguar.Interface.ViewModelBuilder
{
    public interface ITransactionViewModelBuilder
    {
        TransactionViewModel Build(int accountId);
    }
}
