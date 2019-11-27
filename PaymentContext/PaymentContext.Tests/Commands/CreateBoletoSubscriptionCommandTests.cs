using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestClass]
        public class DocumentTests
        {
            //Red, Green, Refactor metodo de testes
            [TestMethod]
            public void ErrorWhenNameIsInvalid()
            {
                var command = new CreateBoletoSubscriptionCommand();
                command.FirstName = "";
                command.Validate();
                Assert.IsTrue(command.Invalid);
            }
        }
    }
}