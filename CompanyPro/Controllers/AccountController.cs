using CompanyPro.Models;
using CompanyPro.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompanyPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> UserManager
            ,SignInManager<ApplicationUser> SignInManager)
        {
            userManager = UserManager;
            signInManager = SignInManager;
        }
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    PasswordHash=userVM.Password,
                    Address=userVM.Address
                };
                //save 
                IdentityResult result= await userManager.CreateAsync(user,userVM.Password);
                
                if (result.Succeeded)
                {
                    IdentityResult resultRole= await userManager.AddToRoleAsync(user, "Admin");
                    //userManager.AddClaimsAsync()//extar info
                    await signInManager.SignInAsync(user, false);//session cookie
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var item in result.Errors)
                   ModelState.AddModelError("", item.Description);
            }
            return View("Register", userVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel uservm)
        {
            if (ModelState.IsValid == true)
            {
                //check
                ApplicationUser userDB=
                    await userManager.FindByNameAsync(uservm.UserName);
                if (userDB != null)
                {
                    //check passwor
                    bool found = 
                        await userManager.CheckPasswordAsync(userDB, uservm.Password);
                    if (found)
                    {
                        //add cookie extra info
                        /* 
                         List<Claim> Claims = new List<Claim>();
                         Claims.Add(new Claim("Institute", "ITI"));
                        Claims.Add(new Claim("Address",userDB.Address));
                         await signInManager.SignInWithClaimsAsync(userDB, uservm.RememberMe, Claims);*/

                        await signInManager.SignInAsync(userDB, uservm.RememberMe);//Id,Name,[Role]
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
                //creat 
            }
            return View("Login",uservm);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


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

    }
}
