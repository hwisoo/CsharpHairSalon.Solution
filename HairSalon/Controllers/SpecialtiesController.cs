using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {

    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialties/new")]
    public ActionResult Create(string specialtyName)
    {
      Specialty newSpecialty = new Specialty(specialtyName);
      newSpecialty.Save();

      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialties/delete")]
    public ActionResult DeleteAll()
    {
      Specialty.ClearAll();
      return View();
    }

    [HttpGet("/specialties/{specialtyId}")]
    public ActionResult Show(int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(specialtyId);
      List<Stylist> specialtyStylists = Specialty.GetStylists(specialtyId);
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpGet("/specialties/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Specialty specialty = Specialty.Find(id);
      Specialty.DeleteSpecialty(id);
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpPost("/specialties/{specialtyId}/addStylist")]
    public ActionResult AddStylist(int specialtyId, int stylistAdded)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(specialtyId);
      Stylist stylist = Stylist.Find(stylistAdded);
      selectedSpecialty.AddStylist(stylist);
      List<Stylist> specialtyStylists = Specialty.GetStylists(specialtyId);
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      model.Add("specialty", selectedSpecialty);
      return View("Show", model);
    }
  }
}