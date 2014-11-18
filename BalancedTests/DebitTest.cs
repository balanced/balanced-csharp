using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;
using Balanced.Exceptions;
using System.Text;
using System.IO;
using Moq;
using System.Net;

namespace BalancedTests
{
    [TestClass]
    public class DebitTest : BaseTest
    {
        [TestMethod]
        public void TestDebitCreate()
        {
            Customer customer = createPersonCustomer();
            Card card = createCard();
            card.AssociateToCustomer(customer);

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 10000);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            Debit debit = card.Debit(payload);
            Assert.IsNotNull(debit.href);
            Assert.AreEqual(10000, debit.amount);
            Assert.AreEqual("A simple debit", debit.description);
        }

        [TestMethod]
        public void TestFailedDebitAPIException()
        {
            Customer customer = createPersonCustomer();
            Card card = createPorcessorErrorCard();
            card.AssociateToCustomer(customer);

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 0);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            try
            {
                Debit debit = card.Debit(payload);
            }
            catch (Balanced.Exceptions.APIException ex)
            {
                Assert.IsTrue(string.IsNullOrEmpty(ex.additional));
                Assert.IsInstanceOfType(ex.extras, typeof(Dictionary<String, String>));
            }


        }

        [TestMethod]
        public void TestDebitCreateNoCustomer()
        {
            Card card = createCard();

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 10000);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            Debit debit = card.Debit(payload);
            Assert.IsNotNull(debit.href);
            Assert.AreEqual(10000, debit.amount);
            Assert.AreEqual("A simple debit", debit.description);
        }

        [TestMethod]
        public void TestRefund()
        {
            Card card = createCard();

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 10000);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            Debit debit = card.Debit(payload);
            Assert.IsNotNull(debit.href);
            Assert.AreEqual(10000, debit.amount);
            Assert.AreEqual("A simple debit", debit.description);

            Refund refund = debit.Refund();

            Assert.AreEqual(debit.amount, refund.amount);
        }

        [TestMethod]
        public void TestDebitBankAccountVerified()
        {
            Customer customer = new Customer();
            customer.Save();

            BankAccount ba = createBankAccount();

            BankAccountVerification bankAccountVerification = ba.Verify();
            bankAccountVerification.Confirm(1, 1);
            bankAccountVerification.Reload();

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);

            Debit debit = ba.Debit(payload);

            Assert.AreEqual("succeeded", debit.status);
            Assert.AreEqual(100000, debit.amount);
        }

        [TestMethod]
        public void TestDebitBankAccountUnverifiedNoCustomer()
        {
            Customer customer = new Customer();
            customer.Save();

            BankAccount ba = createBankAccount();
            BankAccountVerification verification = ba.Verify();
            verification.Confirm(1, 1);

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);

            Debit debit = ba.Debit(payload);

            Assert.AreEqual("succeeded", debit.status);
            Assert.AreEqual(100000, debit.amount);
        }

        [TestMethod]
        [ExpectedException(typeof(HTTPException))]
        public void TestEmptyHttpResponseCustomer()
        {


            // arrange
            var expected = "response content";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            Exception innerException = new Exception("Time out");

            var innerResponse = new Mock<HttpWebResponse>();
            
            innerResponse.Setup(c => c.GetResponseStream()).Returns(responseStream);
            innerResponse.Setup(c => c.StatusCode).Returns(HttpStatusCode.InternalServerError);

            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Throws(
                new WebException("an error occurred", innerException, WebExceptionStatus.UnknownError, innerResponse.Object)
            );

            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponse()).Returns(response.Object);

            var factory = new Mock<IHttpWebRequestFactory>();
            factory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(request.Object);

            // act
            var actualRequest = factory.Object.Create("http://www.google.com");
            actualRequest.Method = WebRequestMethods.Http.Get;

            Client.processResponse(actualRequest);
        }

        public interface IHttpWebRequestFactory
        {
            HttpWebRequest Create(string uri);
        }

        [TestMethod]
        public void TestDebitFilter()
        {
            Debit[] debits = new Debit[3];
            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);
            Dictionary<string, object> payload2 = new Dictionary<string, object>();
            payload2.Add("amount", 777);
            Dictionary<string, object> payload3 = new Dictionary<string, object>();
            payload3.Add("amount", 555);

            Card card = createCard();
            debits[0] = card.Debit(payload);
            debits[1] = card.Debit(payload2);
            debits[2] = card.Debit(payload3);

            ResourceQuery<Debit> query = card.debits.Query().Filter("amount", "=", 777);
            Assert.AreEqual(1, query.Total());
            Debit res = query.First();
            Assert.AreEqual(debits[1].id, res.id);

            query = card.debits.Query().Filter("amount", 777);
            Assert.AreEqual(1, query.Total());
            Assert.AreEqual(debits[1].id, query.First().id);

            query = (
                card
                .debits
                .Query()
                .Filter("amount", "<", 800)
                .OrderBy("created_at", ResourceQuery<Debit>.SortOrder.ASCENDING)
            );
            Assert.AreEqual(2, query.Total());

            List<Debit> allDebits = query.All();
            Assert.AreEqual(debits[1].id, allDebits[0].id);
            Assert.AreEqual(debits[2].id, allDebits[1].id);

            query = (
                    card
                    .debits
                    .Query()
                    .Filter("amount", ">", 600)
                    .Filter("amount", "<", 800)
                    .OrderBy("amount", ResourceQuery<Debit>.SortOrder.DESCENDING)
                );
            Assert.AreEqual(1, query.Total());

            allDebits = query.All();
            Assert.AreEqual(debits[1].id, allDebits[0].id);
        }
    }
}
