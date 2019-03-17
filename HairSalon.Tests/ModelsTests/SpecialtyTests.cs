using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
      public void Dispose()
      {
          Specialty.ClearAll();
           Stylist.ClearAll();
      }

      public SpecialtyTest()
      {
           DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
      }

      [TestMethod]
      public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
      {
          Specialty newSpecialty = new Specialty("test");
          Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
      }

      [TestMethod]
      public void GetDescription_ReturnsDescription_String()
      {
          //Arrange
          string description = "Walk the dog.";
          Specialty newSpecialty = new Specialty(description);

          //Act
          string result = newSpecialty.GetDescription();

          //Assert
          Assert.AreEqual(description, result);
      }

      [TestMethod]
      public void SetDescription_SetDescription_String()
      {
          //Arrange
          string description = "Walk the dog.";
          Specialty newSpecialty = new Specialty(description);

          //Act
          string updatedDescription = "Do the dishes.";
          newSpecialty.SetDescription(updatedDescription);
          string result = newSpecialty.GetDescription();
          
          //Assert
          Assert.AreEqual(updatedDescription, result);
      }

      [TestMethod]
      public void GetAll_ReturnsItems_ItemList()
      {
          //Arrange
          string description01 = "Walk the dog.";
          string description02 = "Wash the dishes.";
          Specialty newSpecialty1 = new Specialty(description01);
          newSpecialty1.Save();
          Specialty newSpecialty2 = new Specialty(description02);
          newSpecialty2.Save();
          List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };

          //Act
          List<Specialty> result = Specialty.GetAll();

          //Assert
          CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Mow the lawn", 1);
          testSpecialty.Save();

          //Act
          Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

          //Assert
          Assert.AreEqual(testSpecialty, foundSpecialty);
      }

      [TestMethod]
      public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Specialty()
      {
          //Arrange, Act
          Specialty firstSpecialty = new Specialty("Mow the lawn", 1);
          Specialty secondSpecialty = new Specialty("Mow the lawn", 1);

          //Assert
          Assert.AreEqual(firstSpecialty, secondSpecialty);
      }

      [TestMethod]
      public void Save_SavesToDatabase_SpecialtyList()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Mow the lawn");

          //Act
          testSpecialty.Save();
          List<Specialty> result = Specialty.GetAll();
          List<Specialty> testList = new List<Specialty>{testSpecialty};

          //Assert
          CollectionAssert.AreEqual(testList, result);
      }

      [TestMethod]
      public void Save_AssignsIdToObject_Id()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Mow the lawn");

          //Act 
          testSpecialty.Save();
          Specialty savedSpecialty = Specialty.GetAll()[0];

          int result = savedSpecialty.GetId();
          int testId = testSpecialty.GetId();

          //Assert
          Assert.AreEqual(testId, result);
      }

      [TestMethod]
      public void Edit_UpdatesSpecialtyInDatabase_String()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Walk the Dog", 1);
          testSpecialty.Save();
          string secondDescription = "Mow the lawn";

          //Act
          testSpecialty.Edit(secondDescription);
          string result = Specialty.Find(testSpecialty.GetId()).GetDescription();

          //Assert
          Assert.AreEqual(secondDescription, result);
      }

      [TestMethod]
      public void GetStylists_ReturnsAllSpecialtyStylists_StylistList()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Mow the lawn");
          testSpecialty.Save();
          Stylist testStylist1  = new Stylist("Home stuff");
          testStylist1.Save();
          Stylist testStylist2 = new Stylist("Work stuff");
          testStylist2.Save();

          //Act
          testSpecialty.AddStylist(testStylist1);
          List<Stylist> result = testSpecialty.GetStylists();
          List<Stylist> testList = new List<Stylist> {testStylist1};

          //Assert
          CollectionAssert.AreEqual(testList, result);
      }

      [TestMethod]
      public void AddStylist_AddsStylistToSpecialty_SpecialtyList()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Mow the lawn");
          testSpecialty.Save();
          Stylist testStylist = new Stylist("Home stuff");
          testStylist.Save();

          //Act
          testSpecialty.AddStylist(testStylist);

          List<Stylist> result = testSpecialty.GetStylists();
          List<Stylist> testList = new List<Stylist>{testStylist};

          //Assert
          CollectionAssert.AreEqual(testList, result);
      }
  }
}