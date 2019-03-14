using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
      public void Dispose()
      {
          Client.ClearAll();
          Stylist.ClearAll();
      }

      public ClientTest()
      {
           DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
      }

      [TestMethod]
      public void ClientConstructor_CreatesInstanceOfClient_Client()
      {
          Client newClient = new Client("test");
          Assert.AreEqual(typeof(Client), newClient.GetType());
      }

      [TestMethod]
      public void GetDescription_ReturnsDescription_String()
      {
          //Arrange
          string description = "Walk the dog.";
          Client newClient = new Client(description);

          //Act
          string result = newClient.GetDescription;

          //Assert
          Assert.AreEqual(description, result);
      }

      [TestMethod]
      public void SetDescription_SetDescription_String()
      {
          //Arrange
          string description = "Walk the dog.";
          Client newClient = new Client(description);

          //Act
          string updatedDescription = "Do the dishes.";
          newClient.SetDescription(updatedDescription);
          string result = newClient.GetDescription();
          
          //Assert
          Assert.AreEqual(updatedDescription, result);
      }

      [TestMethod]
      public void GetAll_ReturnsItems_ItemList()
      {
          //Arrange
          string description01 = "Walk the dog.";
          string description02 = "Wash the dishes.";
          Client newClient1 = new Client(description01);
          newClient1.Save();
          Client newClient2 = new Client(GetDescription)
      }
  }
}