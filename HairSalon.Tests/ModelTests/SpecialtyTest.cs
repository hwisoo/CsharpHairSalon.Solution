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
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=james_cho_test;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("test", 0);
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "highlights";
      int id = 0;
      Specialty newSpecialty = new Specialty(name, id);

      //Act
      string result = newSpecialty.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void Add_SpecialtyList_To_Database()
    {
        //Arrange
        string name = "highlights";
        int id = 0;
        Specialty newSpecialty = new Specialty(name, id);
        newSpecialty.Save();
        List<Specialty> newList = new List<Specialty> {newSpecialty};

        //Act
       List<Specialty> result = Specialty.GetAll();
      
       //Assert
       Assert.AreEqual(newList.Count, result.Count);
    }

    [TestMethod]
    public void Delete_Specialty_From_Database()
    {
        //Arrange
        string name = "highlights";
        int id = 0;
        Specialty newSpecialty = new Specialty(name, id);
        newSpecialty.Save();
        Specialty.DeleteSpecialty(newSpecialty.GetId());

        //Act
        List<Specialty> result = Specialty.GetAll();
        List<Specialty> testList = new List<Specialty>{};

        //Assert
        CollectionAssert.AreEqual(result, testList);
        
    }

  }
}
