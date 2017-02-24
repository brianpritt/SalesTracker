using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SalesTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTracker.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> _userManager;

        public SalesPersonController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View(_db.Kombuchas.ToList());
        }
        public IActionResult Transaction()
        {
            ViewBag.KombuchaList = new SelectList(_db.Kombuchas, "KomId", "KomName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Transaction(int KombuchaList)
        {
            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine(KombuchaList);
            Transaction newTransaction = new Transaction(KombuchaList, user.Id, 1);
            _db.Transactions.Add(newTransaction);
            _db.SaveChanges();
            var thisKom = _db.Kombuchas.FirstOrDefault(kom => kom.KomId == KombuchaList);
            thisKom.KomQuantity -= 1;
            _db.Entry(thisKom).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
