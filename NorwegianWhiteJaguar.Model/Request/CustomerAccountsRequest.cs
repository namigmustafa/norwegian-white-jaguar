namespace NorwegianWhiteJaguar.Model.Request
{
    public class CustomerAccountsRequest : RequestBase
    {
        public CustomerAccountsRequest(string customerId)
        {
            AddQueryParameter("customerId", customerId);
        }
    }
}
