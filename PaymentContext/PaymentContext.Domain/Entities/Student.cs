using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();
            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }
        public void AddSubscritpion(Subscription subscriptions)
        {
            var hasSubscriptionActive = false;

            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                            .Requires()
                            .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já possui assinatura ativa")
                            .AreEquals(0, subscriptions.Payments.Count, "Student.Subscriptions.Payment", "Esta assinatura não possui pagamentos"));
            //Alternativa
            // if(hasSubscriptionActive)
            // {
            //     AddNotification("Student.Subscription","Você já possui assinatura ativa");
            // }
        }
    }
}