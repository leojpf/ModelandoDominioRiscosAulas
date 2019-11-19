using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string lastTrasnsactionCode,
                             DateTime paidDate,
                             DateTime exipreDate,
                             decimal total,
                             decimal totalPaid,
                             string document,
                             string owner,
                             string address,
                             string email)
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