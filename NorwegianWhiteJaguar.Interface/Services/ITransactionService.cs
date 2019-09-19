namespace NorwegianWhiteJaguar.Interface.ViewModelBuilder
{
    public interface ITransactionService
    {
        void Create(decimal amount, int customerId, int accountId);//TODO should it return Account or AccountDto
    }
}
