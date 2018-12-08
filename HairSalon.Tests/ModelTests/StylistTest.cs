using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=james_cho_test;";
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("test","test","test");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Vidal Sassoon";
      string specialty = "haircuts";
      string schedule = "weekdays";
      int id = 0;
      Stylist newStylist = new Stylist(name, specialty, schedule, id);

      //Act
      string result = newStylist.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void Add_StylistList_To_Database()
    {
        //Arrange
        string name = "Vidal Sassoon";
        string specialty = "haircuts";
        string schedule = "weekdays";
        int id = 0;
        Stylist newStylist = new Stylist(name, specialty, schedule, id);
        newStylist.Save();
        List<Stylist> newList = new List<Stylist> {newStylist};

        //Act
       List<Stylist> result = Stylist.GetAll();

       //Assert
       CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Delete_Stylist_From_Database()
    {
        //Arrange
        string name = "Vidal Sassoon";
        string specialty = "haircuts";
        string schedule = "weekdays";
        int id = 0;
        Stylist newStylist = new Stylist(name, specialty, schedule, id);
        newStylist.Save();
        Stylist.DeleteStylist(newStylist.GetId());

        //Act
        List<Stylist> result = Stylist.GetAll();
        List<Stylist> testList = new List<Stylist>{};

        //Assert
        CollectionAssert.AreEqual(result, testList);
        
    }

    [TestMethod]
    public void Add_Clients_To_Stylist_List()
    {
        //Arrange
        string name = "Vidal Sassoon";
        string specialty = "haircuts";
        string schedule = "weekdays";
        int id = 0;
        Stylist newStylist = new Stylist(name, specialty, schedule, id);
        newStylist.Save();
        Client testClient = new Client("Bob", 7777777, newStylist.GetId(), 1);
        testClient.Save();
        
         //Act
        int stylistId = newStylist.GetId();
        int result = testClient.GetStylistId();

         //Assert
         Assert.AreEqual(stylistId,result);
   }

  }
}
