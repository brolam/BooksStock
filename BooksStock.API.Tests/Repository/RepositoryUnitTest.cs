using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksStock.API.Repository;
using BooksStock.API.Models;

namespace BooksStock.API.Tests.Repository
{
    [TestClass]
    public class RepositoryUnitTest
    {
        BooksStockDataBase _booksStockDataBase;
        [TestInitialize]
        public void SetUP()
        {
            this._booksStockDataBase = new BooksStockDataBase();
            this._booksStockDataBase.DropDataBase();
        }
        [TestMethod]
        public void BooksStockDataBaseCreateWithoutError()
        {
            var booksStockDataBase = new BooksStockDataBase();
            Assert.IsNotNull(booksStockDataBase);
        }

        [TestMethod]
        public BookStock InsertOneBookStock()
        {
            var expectStockUpdated = DateTime.Now;
            var bookStock = new BookStock("One BookStock", 10);
            _booksStockDataBase.BooksStock.Add(bookStock);
            Assert.IsNotNull(bookStock.BookID);
            Assert.IsTrue(bookStock.StockUpdated >= expectStockUpdated, "A data do estoque não foi atualizada!");
            return bookStock;
        }

        [TestMethod]
        public void GetOneBookStock()
        {
            var expectBookStock = InsertOneBookStock();
            var bookStock = _booksStockDataBase.BooksStock.Get(expectBookStock.BookID);
            Assert.IsNotNull(bookStock);
            Assert.AreEqual(expectBookStock.BookID, bookStock.BookID);
            Assert.AreEqual(expectBookStock.BookName, bookStock.BookName);
            Assert.AreEqual(expectBookStock.StockQuantity, bookStock.StockQuantity);
            Assert.AreEqual(expectBookStock.StockUpdated.ToLongDateString(), bookStock.StockUpdated.ToLongDateString());
        }


        [TestMethod]
        public void GetAllBooksStockOrderedByBookName()
        {
            var first = 0;
            var secound = 1;
            BookStock[] expectBooksStock = { new BookStock("1 BookStock", 10), new BookStock("2 BookStock", 10), };
            //Salvar os Books Stock em ordem decrescente
            _booksStockDataBase.BooksStock.Add(expectBooksStock[secound]);
            _booksStockDataBase.BooksStock.Add(expectBooksStock[first]);
            var expectBooksStockOrderdByBookName = _booksStockDataBase.BooksStock.GetAll("BookName").GetEnumerator();
            List<BookStock> booksStock = new List<BookStock>();
            while (expectBooksStockOrderdByBookName.MoveNext())
            {
                var bookStock = expectBooksStockOrderdByBookName.Current;
                booksStock.Add(bookStock);
            }
            //Verificar se os BooksStock foram recuperados em ordem ascendente
            Assert.AreEqual(expectBooksStock[first].BookID, booksStock[first].BookID);
            Assert.AreEqual(expectBooksStock[secound].BookID, booksStock[secound].BookID);
        }

        [TestMethod]
        public void GetAllBooksStockOrderedByStockQuantity()
        {
            var first = 0;
            var secound = 1;
            BookStock[] expectBooksStock = { new BookStock("1 BookStock", 5), new BookStock("2 BookStock", 10), };
            //Salvar os Books Stock em ordem decrescente
            _booksStockDataBase.BooksStock.Add(expectBooksStock[secound]);
            _booksStockDataBase.BooksStock.Add(expectBooksStock[first]);
            var expectBooksStockOrderdByBookName = _booksStockDataBase.BooksStock.GetAll("StockQuantity").GetEnumerator();
            List<BookStock> booksStock = new List<BookStock>();
            while (expectBooksStockOrderdByBookName.MoveNext())
            {
                var bookStock = expectBooksStockOrderdByBookName.Current;
                booksStock.Add(bookStock);
            }
            //Verificar se os BooksStock foram recuperados em ordem ascendente
            Assert.AreEqual(expectBooksStock[first].BookID, booksStock[first].BookID);
            Assert.AreEqual(expectBooksStock[secound].BookID, booksStock[secound].BookID);
        }

        [TestMethod]
        public void UpdateOneBookStock()
        {
            var expectStockUpdated = DateTime.Now;
            var expectBookStock = InsertOneBookStock();
            expectBookStock.BookName = "BookStock Updated";
            expectBookStock.StockQuantity = 0;
            _booksStockDataBase.BooksStock.Update(expectBookStock);
            var bookStockUpdated = _booksStockDataBase.BooksStock.Get(expectBookStock.BookID);
            Assert.AreEqual(expectBookStock.BookID, bookStockUpdated.BookID);
            Assert.AreEqual(expectBookStock.BookName, bookStockUpdated.BookName);
            Assert.AreEqual(expectBookStock.StockQuantity, bookStockUpdated.StockQuantity);
            Assert.IsTrue(expectBookStock.StockUpdated < bookStockUpdated.StockUpdated);
        }
    }
}
