using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        [HttpGet("/stylists")]
        public ActionResult Index() => View(db.Stylists.ToList());

        [HttpGet("/stylists/create")]
        public ActionResult Create() 
        {
           ViewBag.SpecialtyIds = db.Specialties.ToList()
                .Select(specialty => new SelectListItem {
                    Value = specialty.SpecialtyId.ToString(),
                    Text = specialty.Description
                })
                .ToList();
            return View();
        }

        [HttpPost("/stylists/create")]
        public ActionResult Create(Stylist stylist)
        {
            db.Stylists.Add(stylist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist stylist = db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
            var entryList = db.StylistClients.Where(entry => entry.StylistId == id).ToList();
            List<Client> clientList = new List<Client>();
            foreach (var client in entryList)
            {
                int clientId = client.ClientId;
                clientList.Add(db.Clients.FirstOrDefault(record => record.ClientId == clientId));
            }
            ViewBag.ClientList = clientList;
            return View(stylist);
        }

        [HttpPost("stylists/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist stylist = db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
            StylistClient joinEntry = db.StylistClients.FirstOrDefault(entry => entry.StylistId == id);
            db.Stylists.Remove(stylist);
            if (joinEntry != null) db.StylistClients.Remove(joinEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
