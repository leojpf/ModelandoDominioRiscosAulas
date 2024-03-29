using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public Payment(DateTime paidDate, DateTime exipreDate, decimal total, decimal totalPaid, Document document, string owner, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExipreDate = exipreDate;
            Total = total;
            TotalPaid = totalPaid;
            Document = document;
            Owner = owner;
            Address = address;
            Email = email;
            AddNotifications(new Contract().Requires()
                .IsLowerOrEqualsThan(0,Total,"Payment.Total","O total não pode ser 0")
                .IsGreaterOrEqualsThan(Total,TotalPaid,"Payment.TotalPaid","O valor pago é menor que o total"));
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExipreDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Document Document { get; private set; }
        public string Owner { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}