    
using Flunt.Validations;
using Payment.Shared.Commands;

namespace Payment.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : SubscriptionCommand//, ICommand
    {
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
