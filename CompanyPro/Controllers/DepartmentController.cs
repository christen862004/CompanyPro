using CompanyPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

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
        //handel link Open view Empty
        public IActionResult New()
        {
            return View("New");//Model =Null
        }
        //DEpartemnt/SaveNEw?name=fullStack&managername=Ahmed (Method = GEt)
        //HAndel Submit requets (MEthod Post)
        [HttpPost]
        public IActionResult SaveNew(Department Dept)//request method Post
        {
                if (Dept.Name != null)
                {
                    context.Add(Dept);
                    context.SaveChanges();

                    // return View("Index",context.Department.ToList());//view indexx ,model null
                    return RedirectToAction("Index");//index name action
                }
                return View("New",Dept);//View NEw ,model ==>Dept
          
        }
    }
}
