using Flunt.Notifications;
using Flunt.Validations;
using Payment.Domain.Enums;
using Payment.Shared.Commands;
using System;

namespace Payment.Domain.Commands
{
    public abstract class SubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocumentNumber { get; set; }

        public string Email { get; set; }

        public string PaymentNumber { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public string Payer { get; set; }

        public string PayerEmail { get; set; }

        public EDocumentType PayerDocumentType { get; set; }

        public string PayerDocument { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(FirstName, 2, "Name.FirstName", "O Nome deve conter no mínimo 2 caracteres")
               .HasMinLen(LastName, 2, "Name.LastName", "O Sobrenome deve conter no mínimo 2 caracteres")
               .HasMaxLen(FirstName, 50, "Name.FirstName", "O Nome deve conter no máximo 50 caracteres")
               .HasMaxLen(LastName, 50, "Name.LastName", "O Sobrenome deve conter no máximo 50 caracteres")
               );

            return this.Valid;

        }
    }
}
