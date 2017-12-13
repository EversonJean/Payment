using System;

namespace Payment.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardName, string lastTransactionNumber, DateTime paidDate, DateTime expireDate,
            decimal total, decimal totalPaid, string address, string document, string payer, string email)
            : base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            CardHolderName = cardHolderName;
            CardName = cardName;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; set; }
        public string CardName { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}
