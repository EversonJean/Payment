using Flunt.Validations;
using Payment.Domain.ValueObjects;
using Payment.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        /// <summary>
        /// As notificações(exceptions) obtitas dos ValuesObjects são agrupadas nas notificações desta Entidade
        /// </summary>
        /// <param name="name"></param>
        /// <param name="document"></param>
        /// <param name="email"></param>
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            //AddNotifications(new Contract()
            //    .Requires()
            //    .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
            //    .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Essa assinatura não contem pagamentos")
            //    );

            //Alternativa
            if (hasSubscriptionActive)
                AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");

            if (subscription.Payments.Count == 0)            
                AddNotification("Student.Subscription.Payments", "Essa assinatura não contem pagamentos");

            if(this.Valid)
                _subscriptions.Add(subscription);

        }
    }
}
