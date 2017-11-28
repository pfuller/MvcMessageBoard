using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageBoardWebApp;
using MessageBoardWebApp.Controllers;
using MessageBoardWebApp.Services;
using MessageBoardWebApp.Data;

namespace MessageBoardWebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController createHomeController()
        {
            return new HomeController(new MockMailService(),
                new MessageBoardRepository(new MessageBoardContext()));
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = createHomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = createHomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = createHomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
