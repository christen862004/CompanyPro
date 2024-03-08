using CompanyPro.Models;
using CompanyPro.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace CompanyPro.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext context = new ITIContext();
        IDepartmentRepository DepartmentRepository;
        IEmployeeRepository EmployeeRepository;
        public DepartmentController
            (IEmployeeRepository empRepo,IDepartmentRepository deptREpo)
        {
            DepartmentRepository = deptREpo;
            EmployeeRepository = empRepo;
            //DepartmentRepository = new DepartmentRepository();
            //EmployeeRepository = new EmployeeRepository();
        }

        public IActionResult GetDepartmentsEmps() {
            List<Department> departments = DepartmentRepository.GetAll();
            return View("ShowDEpartments",departments);//view ShowDEpartments ,Model List<department>
        }


        //Department/ShowEmpsPerDepartment?deptID=1
        public IActionResult ShowEmpsPerDepartment(int deptID)
        {
            List<Employee> employees = EmployeeRepository.GetByDepartmentID(deptID);
               
            return Json(employees);/*Data*/
        }




        public IActionResult Index()
        {
            List<Department> DeptListModel= DepartmentRepository.GetAll();
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
                    DepartmentRepository.Insert(Dept);
                    //update
                    DepartmentRepository.Save();

                    // return View("Index",context.Department.ToList());//view indexx ,model null
                    return RedirectToAction("Index");//index name action
                }
                return View("New",Dept);//View NEw ,model ==>Dept
          
        }
    }
}
