using Payment.Domain.Commands;

namespace Payment.Domain.Command
{
    public class CreatePayPalSubscriptionCommand : SubscriptionCommand
    {
        public string TransactionCode { get; set; }
    }
}
