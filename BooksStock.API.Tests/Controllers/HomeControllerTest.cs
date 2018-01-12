using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksStock.API;
using BooksStock.API.Controllers;

namespace BooksStock.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Organizar
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Books Stock API", result.ViewBag.Title);
        }
    }
}
