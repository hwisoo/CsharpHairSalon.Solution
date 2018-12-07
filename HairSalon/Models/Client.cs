using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _phone;
    private int _stylistId;
    private int _id;

    public Client (string name, int phone, int stylistId,int id = 0)
    {
      _name = name;
      _phone = phone;
      _stylistId = stylistId;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetPhone()
    {
      return _phone;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string clientName = rdr.GetString(0);
        int clientPhone = rdr.GetInt32(1);
        int clientId = rdr.GetInt32(2);
        int stylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, clientPhone, clientId, stylistId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static List<Client> GetStylistClients(int id)
    {
      List<Client> stylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = '" + id + "';";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string clientName = rdr.GetString(0);
        int clientPhone = rdr.GetInt32(1);
        int clientId = rdr.GetInt32(2);
        int stylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, clientPhone, clientId, stylistId);
        stylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylistClients;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public static void DeleteClient(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = (@thisId);";
      
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

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
     
      string clientName = "";
      int clientPhone = 0;
      int clientStylistId = 0;
      int clientId = 0;

      while(rdr.Read())
      {
        clientName = rdr.GetString(0);
        clientPhone = rdr.GetInt32(1);
        clientId = rdr.GetInt32(2);
        clientStylistId = rdr.GetInt32(3);
      }
      Client newClient = new Client(clientName, clientPhone, clientId, clientStylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
         Client newClient = (Client) otherClient;
         bool idEquality = this.GetId() == newClient.GetId();
         bool nameEquality = this.GetName() == newClient.GetName();
         bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
         return (idEquality && nameEquality && stylistEquality);
       }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, phone,stylist_id) VALUES (@name, @phone, @stylist_id);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@phone";
      phone.Value = this._phone;
      cmd.Parameters.Add(phone);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newName, int newPhone, int newStylistId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @newName, newPhone = @newPhone, newStylistId = @newStylistId WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@newName";
      clientName.Value = newName;
      cmd.Parameters.Add(clientName);

      MySqlParameter clientPhone = new MySqlParameter();
      clientPhone.ParameterName = "@newPhone";
      clientPhone.Value = newPhone;
      cmd.Parameters.Add(clientPhone);

      MySqlParameter clientStylistId = new MySqlParameter();
      clientStylistId.ParameterName = "@newStylistId";
      clientStylistId.Value = newStylistId;
      cmd.Parameters.Add(clientStylistId);

      cmd.ExecuteNonQuery();
      _name = newName;
      _phone = newPhone;
      _stylistId = newStylistId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
