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

    // [TestMethod]
    // public void Add_CuisineList_To_Database()
    // {
    //     //Arrange
    //     string name = "Indian";
    //     Cuisine newCuisine = new Cuisine(name);
    //     newCuisine.Save();
    //     List<Cuisine> newList = new List<Cuisine> {newCuisine};

    //     //Act
    //    List<Cuisine> result = Cuisine.GetAll();

    //    //Assert
    //    CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void Delete_Cuisine_From_Database()
    // {
    //     //Arrange
    //     string name = "Indian";
    //     Cuisine newCuisine = new Cuisine(name);
    //     newCuisine.Save();
    //     Cuisine.DeleteCuisine(newCuisine.GetId());

    //     //Act
    //     List<Cuisine> result = Cuisine.GetAll();
    //     List<Cuisine> testList = new List<Cuisine>{};

    //     //Assert
    //     CollectionAssert.AreEqual(result, testList);
        
    // }

    // [TestMethod]
    // public void Add_Restaurants_To_Cuisine_List()
    // {
    //     //Arrange
    //      Cuisine newCuisine = new Cuisine("Seafood");
    //      newCuisine.Save();
    //      Restaurant testRestaurant = new Restaurant("Bob's", "Seaside seafood restaurant", "Seattle", "Seafood");
    //      testRestaurant.Save();
    //      Restaurant testRestaurant2 = new Restaurant("Jim's", "local seafood restaurant", "Seattle", "Indian");
    //     testRestaurant2.Save();
    //      //Act
    //      string cuisineList = newCuisine.GetCuisineType();
    //      string result = testRestaurant.GetCuisineType();

    //      //Assert
    //      Assert.AreEqual(cuisineList,result);
   }

  
}
