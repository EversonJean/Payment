namespace Payment.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : SubscriptionCommand
    {
        public string CardHolderName { get; set; }
        public string CardName { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}
