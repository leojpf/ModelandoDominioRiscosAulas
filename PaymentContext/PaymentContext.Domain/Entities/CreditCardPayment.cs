using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string holderName, string cardNumber, string lastTransactionNumber,
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
            HolderName = holderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string HolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}