using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        [HttpGet("/clients")]
        public ActionResult Index() => View(db.Clients.ToList());

        [HttpGet("/clients/create")]
        public ActionResult Create()
        {
            ViewBag.StylistIds = db.Stylists.ToList()
                .Select(stylist => new SelectListItem {
                    Value = stylist.StylistId.ToString(),
                    Text = stylist.StylistFirstName + " " + stylist.StylistLastName
                })
                .ToList();
            return View();
        }

        [HttpPost("/clients/create")]
        public ActionResult Create(Client client, List<int> StylistIds)
        {
            db.Clients.Add(client);
            foreach (int stylistId in StylistIds)
            {
                StylistClient newStylistClient = new StylistClient(client.ClientId, stylistId);
                db.StylistClients.Add(newStylistClient);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client client = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            var entryList = db.StylistClients.Where(entry => entry.ClientId == id).ToList();
            List<Stylist> stylistList = new List<Stylist>();
            foreach (var stylist in entryList)
            {
                int stylistId = stylist.StylistId;
                stylistList.Add(db.Stylists.FirstOrDefault(record => record.StylistId == stylistId));
            }
            ViewBag.StylistList = stylistList;
            return View(client);
        }

        [HttpPost("clients/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Client client = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Client client = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            ViewBag.StylistIds = db.Stylists.ToList()
                .Select(stylist => new SelectListItem {
                    Value = stylist.StylistId.ToString(),
                    Text = stylist.StylistFirstName + " " + stylist.StylistLastName
                })
                .ToList();
            return View(client);
        }

        [HttpPost("/clients/{id}/edit")]
        public ActionResult Edit(Client client, List<int> StylistIds)
        {
            db.Entry(client).State = EntityState.Modified;
            var clientMatchesInJoinTable = db.StylistClients.Where(entry => entry.ClientId == client.ClientId).ToList();

            foreach (var stylist in clientMatchesInJoinTable)
            {
                int stylistId = stylist.StylistId;
                var joinEntry = db.StylistClients
                                    .Where(entry => entry.StylistId == stylistId)
                                    .Where(entry => entry.ClientId == client.ClientId);
                foreach (var entry in joinEntry)
                {
                    db.StylistClients.Remove(entry);
                }
            }

            foreach (var id in StylistIds)
            {
                Stylist stylist = db.Stylists.FirstOrDefault(otherEntry => otherEntry.StylistId == id);
                StylistClient newStylistClient = new StylistClient(client.ClientId, stylist.StylistId);
                db.StylistClients.Add(newStylistClient);
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("clients/delete")]
        public ActionResult DeleteAll()
        {
            foreach (var entry in db.Clients)
            {
                db.Clients.Remove(entry);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}