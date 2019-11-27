using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlersTests
    {
        [TestMethod]
        public void ErrorWhenDocExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999";
            command.Email = "teste@teste.com";
            command.Address = "Endereço";
            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "123465789";
            command.PaidDate = DateTime.Now;
            command.ExipreDate = DateTime.Now.AddMonths(1);
            command.Total = 10;
            command.TotalPaid = 10;
            command.OwnerDocument = "05773564700";
            command.OwnerType = EDocumentType.CPF;
            command.Owner = "Leonardo Pita";
            command.OwnerEmail = "leojpf@gmail.com";
            command.Street = "Mem de Sá";
            command.Number = "123";
            command.Neighborhood = "Icarai";
            command.State = "Rio de Janeiro";
            command.Country = "Brasil";
            command.ZipCode = "123465";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);

        }
    }
}