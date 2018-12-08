using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {

      [TestMethod]
      public void Create_ReturnsCorrectActionType_ActionResult()
      {
        //Arrange
        ClientsController controller = new ClientsController();
      
        //Act
        IActionResult view = controller.New(1);
      
        //Assert
        Assert.IsInstanceOfType(view, typeof(ActionResult));
      }
      

    }
}
