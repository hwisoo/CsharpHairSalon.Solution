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
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=james_cho_test;";
        }

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
            Client newClient = new Client("test", 777, 7);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            //Arrange
            string name = "jimmy";
            int phone = 777;
            int id = 0;
            Client newClient = new Client(name, phone, id);

            //Act
            string result = newClient.GetName();

            //Assert
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void Add_Client_To_Database()
        {
            //Arrange
            string name = "jimmy";
            int phone = 777;
            int id = 0;
            Client newClient = new Client(name, phone, id);
            newClient.Save();
            List<Client> newList = new List<Client> { newClient };

            //Act
            List<Client> result = Client.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Delete_Client_From_Database()
        {
            //Arrange
            string name = "jimmy";
            int phone = 777;
            int id = 0;
            Client newClient = new Client(name, phone, id);
            newClient.Save();
            Client.DeleteClient(newClient.GetId());

            //Act
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { };

            //Assert
            CollectionAssert.AreEqual(result, testList);

        }

        [TestMethod]
        public void Add_Clients_To_Stylist_List()
        {
            //Arrange
            string name = "Vidal Sassoon";
            string schedule = "weekdays";
            int id = 0;
            Stylist newStylist = new Stylist(name, schedule, id);
            newStylist.Save();
            Client testClient = new Client("Bob", 7777777, newStylist.GetId(), 1);
            testClient.Save();

            //Act
            int stylistId = newStylist.GetId();
            int result = testClient.GetStylistId();

            //Assert
            Assert.AreEqual(stylistId, result);
        }

    }
}
