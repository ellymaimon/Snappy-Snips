using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;

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
    }
}
