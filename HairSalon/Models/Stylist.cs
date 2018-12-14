using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private string _schedule;
    private int _id;

    public Stylist(string name, string schedule, int id = 0)
    {

      _name = name;
      _schedule = schedule;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetSchedule()
    {
      return _schedule;
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
      List<Stylist> allStylists = new List<Stylist> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string stylistName = rdr.GetString(0);
        string stylistSchedule = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Stylist newStylist = new Stylist(stylistName, stylistSchedule, stylistId);
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
      string stylistSchedule = "";
      while (rdr.Read())
      {
        stylistName = rdr.GetString(0);
        stylistSchedule = rdr.GetString(1);
        stylistId = rdr.GetInt32(2);
      }
      Stylist foundStylist = new Stylist(stylistName, stylistSchedule, stylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public List<Client> GetClients()
    {
      List<Client> allStylistClients = new List<Client> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@stylist_id";
      stylist_id.Value = this._id;
      cmd.Parameters.Add(stylist_id);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string ClientName = rdr.GetString(0);
        int ClientPhone = rdr.GetInt32(1);
        int ClientStylistId = rdr.GetInt32(2);
        int ClientId = rdr.GetInt32(3);

        Client newClient = new Client(ClientName, ClientPhone, ClientStylistId, ClientId);
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
        Stylist newStylist = (Stylist)otherStylist;
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
      cmd.CommandText = @"INSERT INTO stylists (name, schedule) VALUES (@stylistName, @stylistSchedule);";
      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@stylistName";
      stylistName.Value = this._name;
      cmd.Parameters.Add(stylistName);

      MySqlParameter stylistSchedule = new MySqlParameter();
      stylistSchedule.ParameterName = "@stylistSchedule";
      stylistSchedule.Value = this._schedule;
      cmd.Parameters.Add(stylistSchedule);
      cmd.ExecuteNonQuery();
      _id = (int)cmd.LastInsertedId;
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

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @newName WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter schedule = new MySqlParameter();
      schedule.ParameterName = "@schedule";
      schedule.Value = _schedule;
      cmd.Parameters.Add(schedule);
      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Specialty> GetSpecialties(int id)
    {
      List<Specialty> stylistSpecialties = new List<Specialty> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM stylists
                JOIN stylists_specialties on (stylists.id = stylists_specialties.stylist_id)
                JOIN specialties ON (stylists_specialties.specialty_id = specialties.id)
                WHERE stylists.id = @StylistId;";
      cmd.Parameters.AddWithValue("@StylistId", id);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {  
        string specialtyName = rdr.GetString(0);
        int specialtyId = rdr.GetInt32(1);

        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        stylistSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylistSpecialties;
    }

            public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@StylistId";
            stylist_id.Value = _id;
            cmd.Parameters.Add(stylist_id);
            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@SpecialtyId";
            specialty_id.Value = newSpecialty.GetId();
            cmd.Parameters.Add(specialty_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void RemoveSpecialty(Specialty specialtyToDelete)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = 
             @"DELETE FROM stylists_specialties 
             WHERE specialty_id = (@SpecialtyId);";
            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@SpecialtyId";
            specialtyId.Value = specialtyToDelete.GetId();
            cmd.Parameters.Add(specialtyId);
            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }
  }
}
