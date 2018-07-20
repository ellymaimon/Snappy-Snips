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
    }
}