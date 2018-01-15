using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;

namespace Payment.Tests.Commands
{
    [TestClass]
   public class CommandTests
    {
        [TestMethod]
        public void CommandInvalidReturn()
        {
            var command = new CreateBoletoSubscriptionCommand() { FirstName = "", LastName = ""};
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
        
    }
}
