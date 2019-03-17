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
    
    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
   }
    
    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      List<Client> allClients = Client.GetAll();   
      List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
      List<Specialty> allSpecialties = Specialty.GetAll();
      model.Add("stylist", selectedStylist);
      model.Add("stylistClients", stylistClients);  
      model.Add("allClients", allClients);
      model.Add("stylistSpecialties", stylistSpecialties);  
      model.Add("allSpecialties", allSpecialties);
      return View(model);
    }
    [HttpPost("/stylists/{stylistId}/clients/new")]
    public ActionResult AddClient(int stylistId, int clientId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Client client = Client.Find(clientId);
      stylist.AddClient(client);
      return RedirectToAction("Show",  new { id = stylistId });
    }

    [HttpPost("/stylists/{stylistId}/specialties/new")]
    public ActionResult AddSpecialty(int stylistId, int specialtyId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Specialty specialty = Specialty.Find(specialtyId);
      stylist.AddSpecialty(specialty);
      return RedirectToAction("Show",  new { id = stylistId });
    }
  }
}