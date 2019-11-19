using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string lastTrasnsactionCode,
                             DateTime paidDate,
                             DateTime exipreDate,
                             decimal total,
                             decimal totalPaid,
                             Document document,
                             string owner,
                             Address address,
                             Email email)
                             :base(paidDate,
                                   exipreDate,
                                   total,
                                   totalPaid,
                                   document,
                                   owner,
                                   address,
                                   email)
        {
            LastTrasnsactionCode = lastTrasnsactionCode;
        }

        public string LastTrasnsactionCode { get; private set; }
    }
}