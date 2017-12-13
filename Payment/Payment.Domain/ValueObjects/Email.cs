using Payment.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}
