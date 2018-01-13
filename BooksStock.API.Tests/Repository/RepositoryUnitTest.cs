using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksStock.API.Repository;
using BooksStock.API.Models;

namespace BooksStock.API.Tests.Repository
{
    [TestClass]
    public class RepositoryUnitTest
    {
        BooksStockDataBase booksStockDataBase;
        [TestInitialize]
        public void SetUP()
        {
            this.booksStockDataBase = new BooksStockDataBase();
            this.booksStockDataBase.DropDataBase();
        }
        [TestMethod]
        public void BooksStockDataBaseCreateWithoutError()
        {
            var booksStockDataBase = new BooksStockDataBase();
            Assert.IsNotNull(booksStockDataBase);
        }

        [TestMethod]
        public void InsertOneBookStock()
        {
            var expectStockUpdated = DateTime.Now;
            var bookStock = new BookStock("One BookStock", 10);
            booksStockDataBase.BooksStock.Add(bookStock);
            Assert.IsNotNull(bookStock.BookID);
            Assert.IsTrue(bookStock.StockUpdated >= expectStockUpdated, "A data do estoque não foi atualizada!");
        }
    }
}
