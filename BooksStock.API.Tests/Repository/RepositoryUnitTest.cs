using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksStock.API.Repository;

namespace BooksStock.API.Tests.Repository
{
    [TestClass]
    public class RepositoryUnitTest
    {
        [TestMethod]
        public void BooksStockDataBaseCreateWithoutError()
        {
            var booksStockDataBase = new BooksStockDataBase();
            Assert.IsNotNull(booksStockDataBase);
        }
    }
}
