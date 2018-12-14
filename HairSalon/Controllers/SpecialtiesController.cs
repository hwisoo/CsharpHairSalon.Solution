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
    
    [HttpGet("/specialties/{id}/delete")]
     public ActionResult Delete(int id)
    {
    Specialty specialty = Specialty.Find(id);
    Specialty.DeleteSpecialty(id);
    List<Specialty> allSpecialties = Specialty.GetAll();
    return View("Index", allSpecialties);
    }
  }
}