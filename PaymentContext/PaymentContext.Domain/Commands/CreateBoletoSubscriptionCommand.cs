using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable , ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExipreDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string OwnerDocument { get; set; }
        public EDocumentType OwnerType { get; set; }
        public string Owner { get; set; }
        public string OwnerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
                       AddNotifications(new Contract().Requires()
                                           .HasMinLen(FirstName, 3, "Name.FirstName","Nome deve conter mais de 3 caracteres")
                                           .HasMinLen(LastName,3,"Name.LastName","Sobrenome de conter pelo menos 3 caracteres")
                                           .HasMaxLen(FirstName,40,"Name.FirstName","Nome deve conter até 40 caracteres"));
        }
    }
}