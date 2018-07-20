using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            return View(db.Stylists.ToList());
        }

        [HttpGet("/stylists/create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}
