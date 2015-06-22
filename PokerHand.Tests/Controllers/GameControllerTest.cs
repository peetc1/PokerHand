﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Business.Objects;
using PokerHand.Controllers;
using PokerHand.Models;

namespace PokerHand.Tests.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void UserGoesToGamePageFirst()
        {
            // Arrange
            var controller = new GameController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UserEntersDataGoesToGamePage()
        {
            // Arrange
            var controller = new GameController();

            // Act
            var result = controller.Index("p1", "p2") as ViewResult;
            var model = (GameModel)result.ViewData.Model;


            // Assert
            Assert.IsNotNull(model.Player1);
            Assert.IsNotNull(model.Player2);
        }
    }
}
