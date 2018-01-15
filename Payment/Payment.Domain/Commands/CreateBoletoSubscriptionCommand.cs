
using Flunt.Validations;
using Payment.Domain.Interfaces.Command;

namespace Payment.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : SubscriptionCommand
    {
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
