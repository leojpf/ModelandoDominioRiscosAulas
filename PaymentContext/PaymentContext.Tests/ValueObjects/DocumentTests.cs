using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {

        //Red, Green, Refactor metodo de testes
        [TestMethod]
        public void ErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123",EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void SuccessWhenCNPJIsValid()
        {
            var doc = new Document("03112784000138",EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ErrorWhenCPFIsInvalid()
        {
            var doc = new Document("456",EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void SuccessWhenCPFIsValid()
        {
            var doc = new Document("86469069061",EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}