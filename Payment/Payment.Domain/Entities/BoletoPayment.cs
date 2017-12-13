using System;

namespace Payment.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total,
            decimal totalPaid, string address, string document, string payer, string email) 
            : base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
