using CompanyPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Index()
        {
            List<Department> DeptListModel=
                context.Department.ToList();
            return View("Index",DeptListModel);//View =Index ,Model Type=List<department>
        }
    }
}
