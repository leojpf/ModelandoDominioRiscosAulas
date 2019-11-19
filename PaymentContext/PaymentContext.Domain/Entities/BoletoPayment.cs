using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string boletoNumber,
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}