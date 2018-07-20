using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        [HttpGet("/specialties")]
        public ActionResult Index() => View(db.Specialties.ToList());

        [HttpGet("/specialties/create")]
        public ActionResult Create() => View();

        [HttpPost("/specialties/create")]
        public ActionResult Create(Specialty specialty)
        {
            db.Specialties.Add(specialty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/{id}")]
        public ActionResult Details(int id)
        {
            Specialty specialty = db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
            var entryList = db.StylistSpecialties.Where(entry => entry.SpecialtyId == id).ToList();
            List<Stylist> stylistList = new List<Stylist>();
            foreach (var stylist in entryList)
            {
                int stylistId = stylist.StylistId;
                stylistList.Add(db.Stylists.FirstOrDefault(record => record.StylistId == stylistId));
            }
            ViewBag.StylistList = stylistList;
            return View(specialty);
        }
    }
}