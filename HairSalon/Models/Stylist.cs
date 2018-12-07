using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
    private string _name;
    private int _id;

    public Stylist(string name, int id = 0)
    {
    
      _name = name;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string stylistName = rdr.GetString(0);
        int stylistId = rdr.GetInt32(1);
        Stylist newStylist = new Stylist( stylistName, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string stylistName = "";
      while(rdr.Read())
      {
        stylistName = rdr.GetString(0);
        stylistId = rdr.GetInt32(1);
      }
      Stylist foundStylist = new Stylist( stylistName,  stylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public List<Client> GetClients()
    {
      List<Client> allStylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@stylist_id";
      stylist_id.Value = this._id;
      cmd.Parameters.Add(stylist_id);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string ClientName = rdr.GetString(0);
        int ClientPhone = rdr.GetInt32(1);
        int ClientStylistId = rdr.GetInt32(2);
        int ClientId = rdr.GetInt32(3);
        
        Client newClient = new Client(ClientName,  ClientPhone, ClientStylistId, ClientId);
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylistClients;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool stylistIdEquality = this.GetId().Equals(newStylist.GetId());
        bool stylistNameEquality = this.GetName().Equals(newStylist.GetName());
        return (stylistIdEquality && stylistNameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@stylistName);";
      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@stylistName";
      stylistName.Value = this._name;
      cmd.Parameters.Add(stylistName);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

     public static void DeleteStylist(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = (@thisId);";
      
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }
    }
}
