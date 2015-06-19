using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand;
using PokerHand.Controllers;
using PokerHand.Models;

namespace PokerHand.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void UserGoesToHomepage()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserGoesToGamePageFirst()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Game() as ViewResult;
            
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UserEntersDataGoesToGamePage()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Game(new IndexModel
            {
                UserName1 = "p1",
                UserName2 = "p2"
            }) as ViewResult;
            var model = (GameModel) result.ViewData.Model;


            // Assert
            Assert.IsNotNull(model.User1);
            Assert.IsNotNull(model.User2);
        }
    }
}
