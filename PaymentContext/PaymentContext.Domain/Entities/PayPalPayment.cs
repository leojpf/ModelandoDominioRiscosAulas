using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string trasnsactionCode,
                             DateTime paidDate,
                             DateTime exipreDate,
                             decimal total,
                             decimal totalPaid,
                             Document document,
                             string owner,
                             Address address,
                             Email email)
                             : base(paidDate,
                                   exipreDate,
                                   total,
                                   totalPaid,
                                   document,
                                   owner,
                                   address,
                                   email)
        {

            TrasnsactionCode = trasnsactionCode;
        }

        public string TrasnsactionCode { get; private set; }
    }
}