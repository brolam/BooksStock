using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksStock.API;
using BooksStock.API.Controllers;

namespace BooksStock.API.Tests.Controllers
{
    [TestClass]
    public class BooksStockControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Organizar
            BooksStockController controller = new BooksStockController();

            // Agir
            IEnumerable<string> result = controller.Get();

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Organizar
            BooksStockController controller = new BooksStockController();

            // Agir
            string result = controller.Get(5);

            // Declarar
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Organizar
            BooksStockController controller = new BooksStockController();

            // Agir
            controller.Post("value");

            // Declarar
        }

        [TestMethod]
        public void Put()
        {
            // Organizar
            BooksStockController controller = new BooksStockController();

            // Agir
            controller.Put(5, "value");

            // Declarar
        }

        [TestMethod]
        public void Delete()
        {
            // Organizar
            BooksStockController controller = new BooksStockController();

            // Agir
            controller.Delete(5);

            // Declarar
        }
    }
}
