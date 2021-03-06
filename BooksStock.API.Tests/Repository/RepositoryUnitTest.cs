﻿using System;
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
        public void SetUp()
        {
            this._booksStockDataBase = new BooksStockDataBase();
            this._booksStockDataBase.DropDataBase();
        }

        [TestMethod]
        public void ModelBooksStockDataBaseCreateWithoutError()
        {
            var booksStockDataBase = new BooksStockDataBase();
            Assert.IsNotNull(booksStockDataBase);
        }

        [TestMethod]
        public void ModelInsertOneBookStock() => this.InsertOneBookStock();
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
        public void ModelGetOneBookStock() => this.GetOneBookStock();
        public BookStock GetOneBookStock()
        {
            var expectBookStock = InsertOneBookStock();
            var bookStock = _booksStockDataBase.BooksStock.Get(expectBookStock.BookID);
            Assert.IsNotNull(bookStock);
            Assert.AreEqual(expectBookStock.BookID, bookStock.BookID);
            Assert.AreEqual(expectBookStock.BookName, bookStock.BookName);
            Assert.AreEqual(expectBookStock.StockQuantity, bookStock.StockQuantity);
            Assert.AreEqual(expectBookStock.StockUpdated.ToLongDateString(), bookStock.StockUpdated.ToLongDateString());
            return bookStock;
        }

        [TestMethod]
        public void ModelGetAllBooksStockOrderedByBookName() => this.GetAllBooksStockOrderedByBookName();
        public List<BookStock> GetAllBooksStockOrderedByBookName()
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
            return booksStock;
        }

        [TestMethod]
        public void ModelGetAllBooksStockOrderedByStockQuantity() => this.GetAllBooksStockOrderedByStockQuantity();
        public List<BookStock> GetAllBooksStockOrderedByStockQuantity()
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
            return booksStock;
        }

        [TestMethod]
        public void ModelUpdateOneBookStock()
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

        [TestMethod]
        public void ModelDeleteOneBookStock()
        {
            var savedBookStock = InsertOneBookStock();
            _booksStockDataBase.BooksStock.Delete(savedBookStock.BookID);
            var deletedBookStock = _booksStockDataBase.BooksStock.Get(savedBookStock.BookID);
            Assert.IsNull(deletedBookStock);
        }

        [TestMethod]
        public void ModelBookStockRequiredFields()
        {
            Assert.ThrowsException<Exception>(
                () => new BookStock(null, 10), "O campo BookName deve  validar valores vazio!"
            );
            Assert.ThrowsException<Exception>(
                () => new BookStock("", 10), "O campo BookName deve  validar valores vazio!"
            );
            Assert.ThrowsException<Exception>(
                () => new BookStock("One BookStock", -1), "O campo Stock Quantity deve validar valores negativos!"
            );
        }
    }
}
