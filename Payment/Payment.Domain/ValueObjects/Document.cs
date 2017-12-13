using Payment.Domain.Enums;
using Payment.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }

        public EDocumentType Type { get; private set; }
    }
}
