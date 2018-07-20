using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    }
}