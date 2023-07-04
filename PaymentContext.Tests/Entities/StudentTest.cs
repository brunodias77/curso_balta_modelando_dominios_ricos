using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Payment _payment;
        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
        }
        [TestMethod]
        public void Deve_retornar_erro_quando_há_assinatura_sem_pagamento()
        {
            _student.AddSubscription(_subscription);
            Assert.IsFalse(_student.IsValid);
        }
        [TestMethod]
        public void Deve_retornar_um_erro_quando_houver_uma_assinatura_ativa()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsFalse(_student.IsValid);
        }
        [TestMethod]
        public void Deve_Retornar_Sucesso_Quando_Não_Houver_Assinatura_Ativa()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.IsValid);
        }
    }
}