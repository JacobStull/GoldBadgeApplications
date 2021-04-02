using System;
using System.Collections.Generic;
using Emails;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTests
{
    [TestClass]
    public class EmailsRepoTests
    {
        [TestMethod]
        public void ShouldGetCorrectBoolean()
        {
            EmailProp content = new EmailProp();
            EmailRepo repository = new EmailRepo();
            bool addResult = repository.AddCustomerToList(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ShouldReturnCorrectCollection()
        {
            EmailProp content = new EmailProp();
            EmailRepo repo = new EmailRepo();
            repo.AddCustomerToList(content);
            List<EmailProp> contents = repo.FindCustomer();
            bool directoryHasContent = contents.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        [TestMethod]
        public void ShouldReturnCorrectContent()
        {
            EmailRepo repo = new EmailRepo();
            EmailProp newContent = new EmailProp(0,"123","jacob","stull");
            repo.AddCustomerToList(newContent);
            string id = "123";
            EmailProp searchResult = repo.GetCustomerByID(id);
            Assert.AreEqual(searchResult.ID, id);
        }

        [TestMethod]
        public void ShouldReturnTrue()
        {
            EmailRepo repo = new EmailRepo();
            EmailProp oldContent = new EmailProp();
            repo.AddCustomerToList(oldContent);
            EmailProp newContent = new EmailProp();
            bool updateResult = repo.UpdateExistingCustomer(oldContent.ID, newContent);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void Should_Return_True()
        {
            EmailRepo repo = new EmailRepo();
            EmailProp content = new EmailProp(0, "123", "jacob", "stull");
            repo.AddCustomerToList(content);
            EmailProp oldContent = repo.GetCustomerByID("123");
            bool removeResult = repo.DeleteExisting(oldContent);
            Assert.IsTrue(removeResult);
        }
    }
}
