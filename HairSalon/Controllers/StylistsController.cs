using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        [HttpGet("/stylists")]
        public ActionResult Index() => View(db.Stylists.ToList());

        [HttpGet("/stylists/create")]
        public ActionResult Create() => View();

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
            Stylist author = db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
            var entryList = db.StylistClients.Where(entry => entry.StylistId == id).ToList();
            List<Client> clientList = new List<Client>();
            foreach (var client in entryList)
            {
                int clientId = client.ClientId;
                clientList.Add(db.Clients.FirstOrDefault(record => record.ClientId == clientId));
            }
            ViewBag.BookList = clientList;
            return View(author);
        }
    }
}
