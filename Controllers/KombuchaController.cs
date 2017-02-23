using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTracker.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTracker.Controllers
{
    public class KombuchaController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> _userManager;

        public KombuchaController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BrewList()
        {
            var brewList = _db.Kombuchas.ToList();
            return Json(brewList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewBrew(string newName, string newDescription, double newPrice)
        {
            Kombucha newKombucha = new Kombucha(newName, newDescription, newPrice);
            _db.Kombuchas.Add(newKombucha);
            _db.SaveChanges();
            return Json(newKombucha);
        }
        public IActionResult Details(int id)
        {
            var thisBrew = _db.Kombuchas.FirstOrDefault(kombuchas => kombuchas.KomId == id);
            return View(thisBrew);
        }
        public IActionResult Update()
        {
            return View();
        }
       
        
    }
}
