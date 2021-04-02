using System;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTests
{
    [TestClass]
    public class CafeRepoTests
    {
        [TestMethod]
        public void ShouldGetCorrectBoolean()
        {
            Menu menuItem = new Menu();
            CafeRepo repo = new CafeRepo();
            bool addResult = repo.AddItemToMenu(menuItem);
            Assert.IsTrue(addResult);
        }
    }
}
