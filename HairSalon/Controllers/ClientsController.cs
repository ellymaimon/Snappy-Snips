using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        [HttpGet("/clients")]
        public ActionResult Index() => View(db.Clients.ToList());

        [HttpGet("/clients/create")]
        public ActionResult Create() => View();
    }
}