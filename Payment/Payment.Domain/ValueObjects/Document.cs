using Flunt.Validations;
using Payment.Domain.Enums;
using Payment.Shared.ValueObjects;

namespace Payment.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")                
                );
        }

        public string Number { get; private set; }

        public EDocumentType Type { get; private set; }

        private bool Validate() // Implementação Simples
        {
            if (Type == EDocumentType.CNPJ)
                return Number.Length == 14;

            if (Type == EDocumentType.CPF)
                return Number.Length == 11;

            return false;
        }
    }
}
