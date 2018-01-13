﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksStock.API;
using BooksStock.API.Controllers;
using BooksStock.API.Repository;
using BooksStock.API.Tests.Repository;
using BooksStock.API.Models;

namespace BooksStock.API.Tests.Controllers
{
    [TestClass]
    public class BooksStockControllerTest
    {
        BooksStockController _booksStockController;
        RepositoryUnitTest _repositoryUnitTest;

        [TestInitialize]
        public void SetUp()
        {
            _booksStockController = new BooksStockController();
            _repositoryUnitTest = new RepositoryUnitTest();
            _repositoryUnitTest.SetUp();
        }

        [TestMethod]
        public void GetEmptyBooksStockList()
        {
            var booksStock = _booksStockController.GetAll(fieldAscendingOrder: "BookName");
            Assert.AreEqual(booksStock.Count(), 0);
        }

        [TestMethod]
        public void ApiGetAllBooksStockOrderedByBookName()
        {
            var expectBooksStock = _repositoryUnitTest.GetAllBooksStockOrderedByBookName();
            var booksStockActual = _booksStockController.GetAll(fieldAscendingOrder: "BookName");
            Assert.AreEqual(booksStockActual.Count(), 2);
            this.AsserAreEqualBookStock(expectBooksStock[0], booksStockActual.ElementAt(0));
            this.AsserAreEqualBookStock(expectBooksStock[1], booksStockActual.ElementAt(1));
        }

        [TestMethod]
        public void ApiGetAllBooksStockOrderedByStockQuantity()
        {
            var expectBooksStock = _repositoryUnitTest.GetAllBooksStockOrderedByStockQuantity();
            var booksStockActual = _booksStockController.GetAll(fieldAscendingOrder: "StockQuantity");
            Assert.AreEqual(booksStockActual.Count(), 2);
            this.AsserAreEqualBookStock(expectBooksStock[0], booksStockActual.ElementAt(0));
            this.AsserAreEqualBookStock(expectBooksStock[1], booksStockActual.ElementAt(1));
        }

        [TestMethod]
        public void ApiGetBookStockById()
        {
            var expectBookStock = _repositoryUnitTest.GetOneBookStock();
            var actualBookStock = _booksStockController.Get(expectBookStock.BookID);
            this.AsserAreEqualBookStock(expectBookStock, actualBookStock); ;
        }

        [TestMethod]
        public void ApiGetByBookStocInvalidID()
        {
            var invalidBookStock = _booksStockController.Get("5a5a2ce710458c2c2ce4c584");
            Assert.IsNull(invalidBookStock); ;
        }

        [TestMethod]
        public void ApiPostBookStock()
        {
            var expectStockUpdated = DateTime.Now;
            var newBookStock = new BookStock("One BookStock", 10);
            var savedBookStock = _booksStockController.Post(newBookStock);
            Assert.IsNotNull(savedBookStock.BookID);
            Assert.AreEqual(newBookStock.BookName, savedBookStock.BookName);
            Assert.AreEqual(newBookStock.StockQuantity, savedBookStock.StockQuantity);
            Assert.IsTrue(newBookStock.StockUpdated >= expectStockUpdated, "A data do estoque não foi atualizada!");
        }

        [TestMethod]
        public void ApiPutBookStock()
        {
            var newBookStock = _repositoryUnitTest.InsertOneBookStock();
            newBookStock.BookName = "BookStock Updated";
            newBookStock.StockQuantity = 0;
            var updatedBookStock = _booksStockController.Put(newBookStock);
            this.AsserAreEqualBookStock(updatedBookStock, newBookStock); ;
        }

        [TestMethod]
        public void ApiDeleteBookStock()
        {
            var newBookStock = _repositoryUnitTest.InsertOneBookStock();
            _booksStockController.Delete(newBookStock.BookID);
            var deletedBookStock = _booksStockController.Get(newBookStock.BookID);
            Assert.IsNull(deletedBookStock);
        }

        private void AsserAreEqualBookStock(BookStock expectBookStock, BookStock actualBookStock)
        {
            Assert.AreEqual(expectBookStock.BookID, actualBookStock.BookID);
            Assert.AreEqual(expectBookStock.BookName, actualBookStock.BookName);
            Assert.AreEqual(expectBookStock.StockQuantity, actualBookStock.StockQuantity);
            Assert.AreEqual(expectBookStock.StockUpdated.ToLongDateString(), actualBookStock.StockUpdated.ToLongDateString());
        }
    }


}
