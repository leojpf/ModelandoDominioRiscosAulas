using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("38113573283", Domain.Enums.EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua", "Numero", "Bairro", "Estado", "Pais", "CEP");
            _student = new Student(_name, _document, _email, _address);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ErrorWhenHadActiveSubscription()
        {

            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Industrias Wayne", _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscritpion(_subscription);
            _student.AddSubscritpion(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ErrorWhenActiveSubscriptionHasNoPayment()
        {
            _student.AddSubscritpion(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void SuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Industrias Wayne", _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscritpion(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}