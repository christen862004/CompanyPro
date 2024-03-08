using CompanyPro.Models;
using CompanyPro.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IDepartmentRepository deptREpo;
        private readonly IConfiguration config;

        public ServicesController(IDepartmentRepository DeptREpo,IConfiguration config)//inject (ask)
        {
            deptREpo = DeptREpo;
            this.config = config;
        }
        public IActionResult Index()//[FromServices]IDepartmentRepository _depREpo)
        {
            //config.GetSection()
            ViewBag.Id = deptREpo.Id;
            return View();
        }
    }
}
