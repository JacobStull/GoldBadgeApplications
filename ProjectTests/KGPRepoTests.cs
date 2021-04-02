using System;
using KomodoGreenPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTests
{
    [TestClass]
    public class KGPRepoTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            KomodoGreen car = new KomodoGreen();
            KGPRepo repository = new KGPRepo();
            bool addResult = repository.AddContentToDirectory(car);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetByFuel_ShouldReturnCorrectContent()
        {
            KGPRepo repo = new KGPRepo();
            KomodoGreen newContent = new KomodoGreen("Volkswagen", "Jetta", "anodjlnajkwndka", "Gas");
            repo.AddContentToDirectory(newContent);
            string fuel = "Gas";
            KomodoGreen searchResult = repo.GetContentByFuel(fuel);
            Assert.AreEqual(searchResult.Fuel, fuel);
        }
    }
}
