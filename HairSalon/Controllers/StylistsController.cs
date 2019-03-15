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
      model.Add("stylist", selectedStylist);
      model.Add("stylistClients", stylistClients);  
      model.Add("allClients", allClients);
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
    //
    // // This one creates new Clients within a given Stylist, not new Stylists:
    // [HttpPost("/stylists/{stylistId}/clients")]
    // public ActionResult Create(int stylistId, string clientDescription)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Stylist foundStylist = Stylist.Find(stylistId);
    //   Client newClient = new Client(clientDescription);
    //   newClient.Save();
    //   foundStylist.AddClient(newClient);
    //   List<Client> stylistClients = foundStylist.GetClients();
    //   model.Add("clients", stylistClients);
    //   model.Add("stylist", foundStylist);
    //   return View("Show", model);
    // }

  }
}