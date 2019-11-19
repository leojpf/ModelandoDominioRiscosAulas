using System.Collections.Generic;
using System.Linq;
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
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscriptions.ToArray(); }  }
        public void AddSubscritpion(Subscription subscriptions)
        {
            //Se já existir uma assinatura, é necéssario remover todas e adicionar uma nova.
            foreach (var sub in Subscriptions)
            {
                sub.DeActivate();
            }
            _subscriptions.Add(subscriptions);
        }
        
    }
}