using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }
    
    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }
    
    [HttpPost("/stylists/new")]
    public ActionResult Create(string stylistName,string stylistSchedule)
    {
      Stylist newStylist = new Stylist(stylistName, stylistSchedule);
      newStylist.Save();

      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }
    
       
    [HttpGet("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.ClearAll();
      return View();
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      return View(model);
    }

    [HttpGet("/stylists/{id}/delete")]
     public ActionResult Delete(int id)
    {
    Stylist stylist = Stylist.Find(id);
    Stylist.DeleteStylist(id);
    List<Stylist> allStylists = Stylist.GetAll();
    return View("Index", allStylists);
   
    }

    [HttpGet("/stylists/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Stylist stylist = Stylist.Find(id);
    return View(stylist);
    }

    [HttpPost("/stylists/{id}/edit")]
    public ActionResult Update(int id, string newName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(id);
      stylist.Edit(newName);
      stylist = Stylist.Find(id);
      List<Client> stylistClients = stylist.GetClients();
      model.Add("stylist", stylist);
      model.Add("clients", stylistClients);
    return View("Show", model);
    }
    
    // Adds clients to a stylist
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(string clientName, int clientPhone,int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, clientPhone, stylistId);
      newClient.Save();
      List<Client> stylistClients = foundStylist.GetClients();
      model.Add("clients", stylistClients);
      model.Add("stylist", foundStylist);
      return View("Show", model);
    }

   [HttpGet("/stylists/{stylistId}/clients/{clientId}/delete")]
    public ActionResult Delete(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Client.DeleteClient(client.GetId());
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      List<Client> stylistClients = stylist.GetClients();
      model.Add("stylist", stylist);
      model.Add("clients", stylistClients);
      return View("Show", model);
    }
  }
}
