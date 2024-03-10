using Microsoft.AspNetCore.Mvc;
using CompanyPro.Filtters;
using Microsoft.AspNetCore.Authorization;
namespace CompanyPro.Controllers
{
    [HandelError]
    public class FiltterController : Controller
    {
        public IActionResult Index()
        {
           throw new Exception("Exception throw");
        }
        public IActionResult Index2()
        {
            throw new Exception("Exception throw");
        }
    }
}
