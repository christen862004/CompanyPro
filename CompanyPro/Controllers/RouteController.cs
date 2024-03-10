using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class RouteController : Controller
    {
        //M1 Litteral
        //M1/Mohamed,
        //M1/ahmed/12
        //M1/Ahmed/12/black
        //M/MEthod1
        public IActionResult Method1(string name,int age)
        {
            return Content("M1");
        }
        //M/Method2
        public IActionResult Method2()
        {
            return Content("M2");
        }
        
        [Route("M/{age:int}/{name?}")]//Attribute route
        public IActionResult MEthod3(int age)
        {
            return Content("M2");

        }
    }
}
