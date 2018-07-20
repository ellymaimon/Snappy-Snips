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
                 .Select(specialty => new SelectListItem
                 {
                     Value = specialty.SpecialtyId.ToString(),
                     Text = specialty.Description
                 })
                 .ToList();
            return View();
        }

        [HttpPost("/stylists/create")]
        public ActionResult Create(Stylist stylist, List<int> SpecialtyIds)
        {
            db.Stylists.Add(stylist);
            foreach (int specialtyId in SpecialtyIds)
            {
                StylistSpecialty newStylistSpecialty = new StylistSpecialty(specialtyId, stylist.StylistId);
                db.StylistSpecialties.Add(newStylistSpecialty);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist stylist = db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
            var clientEntries = db.StylistClients.Where(entry => entry.StylistId == id).ToList();
            List<Client> clientList = new List<Client>();
            foreach (var client in clientEntries)
            {
                int clientId = client.ClientId;
                clientList.Add(db.Clients.FirstOrDefault(record => record.ClientId == clientId));
            }
            ViewBag.ClientList = clientList;

            var specialtyEntries = db.StylistSpecialties.Where(entry => entry.StylistId == id).ToList();
            List<Specialty> specialtyList = new List<Specialty>();
            foreach (var specialty in specialtyEntries)
            {
                int specialtyId = specialty.SpecialtyId;
                specialtyList.Add(db.Specialties.FirstOrDefault(record => record.SpecialtyId == specialtyId));
            }
            ViewBag.SpecialtyList = specialtyList;
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

        [HttpPost("stylists/delete")]
        public ActionResult DeleteAll()
        {
            foreach (var entry in db.Stylists)
            {
                db.Stylists.Remove(entry);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
