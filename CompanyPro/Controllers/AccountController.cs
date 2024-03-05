using CompanyPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class AccountController : Controller
    {
        //case
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Index1");
        }
        //account/index
        [HttpPost]
        public IActionResult Index(int id)//0
        {
            return Content("Index2");
        }
        //link open view
        [HttpGet]
        //Account/login (get)
        public IActionResult Login()
        {
            return View("Login");
        }

        //execute after submit button
        //Account/login (post)
        [HttpPost]
        [ValidateAntiForgeryToken]//check request inernal not exxternal (tag helper)
        public IActionResult Login(UserVM user) {
            if(user.Username=="Aya" && user.Passwrod == "Aya")
            {
                return RedirectToAction("Index", "Employee");
            }
            return View("Login",user);
        }
    }
}
