using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.TestTools
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public void Create_ReturnsCorrectActionType_ViewResult()
        {
             //Arrange
             ClientsController controller = new ClientsController();

             //Act 
             IActionResult view = controller.Create("Walk the dog");

             //Assert
             Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

    }
}