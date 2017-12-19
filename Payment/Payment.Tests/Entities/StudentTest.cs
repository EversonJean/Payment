using Flunt.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.ValueObjects;
using System;

namespace Payment.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;

        private readonly Email _email;

        private readonly Address _address;

        private readonly Document _document;

        private readonly Student _student;

        private readonly Subscription _subscription;

        public StudentTest()
        {
            _name = new Name("Everson", "Jean");
            _document = new Document("12312312356", EDocumentType.CPF);
            _email = new Email("teste@teste.com");
            _address = new Address("Rua 1", "1234", "Bairro Lg", "Curitiba", "PR", "BR", "45896563");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ReturnErrorActiveSubs()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "Ever", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ReturnErrorNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ReturnSuccessActiveSubs()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "Ever", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
