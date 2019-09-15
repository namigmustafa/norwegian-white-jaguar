namespace NorwegianWhiteJaguar.Model.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public Account Account { get; set; } //TODO should be there AcountId
    }
}
