using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDuck;
using TextDuck.Controllers;
using TextDuck.Models;

namespace TextDuck.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchTest()
        {
            // Arrange
            HomeController controller = new HomeController();
            var friend = new srtFiles { Title = "Friends" };
            var data = new[] { friend }.AsQueryable();

            var result = controller.Search(data,"Friends");
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(friend, result.First());
        }
        public void RequestTest()
        {
            FileRepository repository = new FileRepository();
            var request = new srtFiles { Status = "Lokið" };
            var data = new[] { request }.AsQueryable();

            var result = repository.GetTexts(data, "Lokið");
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(, result.First());
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
