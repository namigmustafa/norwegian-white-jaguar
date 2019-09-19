namespace NorwegianWhiteJaguar.Model.Request
{
    public class TransactionRequest : RequestBase
    {
        public TransactionRequest(int accountId)
        {
            AddQueryParameter("accountId", accountId.ToString());
        }
    }
}
