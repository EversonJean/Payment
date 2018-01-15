using Flunt.Validations;
using Payment.Shared.ValueObjects;

namespace Payment.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        /// <summary>
        /// Os valores passados são testados e se conter algum erro adiciona as notificações agrupadas na Entidade
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 2, "Name.FirstName", "O Nome deve conter no mínimo 2 caracteres")
                .HasMinLen(LastName, 2, "Name.LastName", "O Sobrenome deve conter no mínimo 2 caracteres")
                .HasMaxLen(FirstName, 50, "Name.FirstName", "O Nome deve conter no máximo 50 caracteres")
                .HasMaxLen(LastName, 50, "Name.LastName", "O Sobrenome deve conter no máximo 50 caracteres")
                );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
