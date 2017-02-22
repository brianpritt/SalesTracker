using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTracker.Models;
using Microsoft.AspNetCore.Identity;
using SalesTracker.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace SalesTracker.Controllers
{

    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(string RoleName)
        {
            try
            {
                _db.Roles.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole()
                {
                    Name = RoleName,
                    NormalizedName = RoleName.ToUpper()
                });
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult GiveHtml()
        {
            return Content("Your password is not safe!!");
        }
    }
}

