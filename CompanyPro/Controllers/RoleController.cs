using CompanyPro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    //Admin
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager)
        {
            roleManager = RoleManager;
        }
        
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
      
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRoleVM)
        {
            if(ModelState.IsValid==true) {
                IdentityRole roleModel = new IdentityRole()
                {
                    Name = newRoleVM.RoleName
                };
                IdentityResult rust= await roleManager.CreateAsync(roleModel);       
                
            }
            return View("AddRole");
        }

    }
}
