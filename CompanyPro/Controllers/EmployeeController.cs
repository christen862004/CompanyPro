using CompanyPro.Models;
using CompanyPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult DEtails(int id)
        {
            //Send Extra Info FRom C#(Action) To View
            
            List<string> Branches=new List<string>();
            Branches.Add("New Capital");
            Branches.Add("Smart");
            Branches.Add("Alex");
            Branches.Add("Manofia");

            int temp = 20;
            //USe ViewData Dictionary Send Extra Info
            //(one request from action to returned view)
            ViewData["brch"] = Branches;
            ViewData["Msg"] = "Hello";
            ViewData["Temp"] = temp;
            ViewData["clr"] = "red";
            ViewData["date"] = DateTime.Now;


            ViewBag.slr = 6000;//viewData["slr"]=1000
            ViewBag.clr = "blue";//ViewData["clr"]="blue"
            Employee EmpModel = context.Employee.FirstOrDefault(e => e.Id == id);
            return View("Details",EmpModel);
        }

        public IActionResult DEtailsWithVM(int id)
        {
            List<string> Branches = new List<string>();
            Branches.Add("New Capital");
            Branches.Add("Smart");
            Branches.Add("Alex");
            Branches.Add("Manofia");

            string msg = "aaa";
            Employee EmpModel = context.Employee.FirstOrDefault(e => e.Id == id);

            //Create ViewModel
            EmpDataWithBrnchListColorTempDateViewModel empVM 
                = new EmpDataWithBrnchListColorTempDateViewModel();
            //Map FRom Model To VM (automapper)

            empVM.EmpID = EmpModel.Id;
            empVM.EmpName= EmpModel.Name;
            empVM.Brcnches = Branches;
            empVM.Msg = "Hello VM";
            empVM.Color = "red";
            empVM.Temp = 20;
            //return view with VM
            return View("DEtailsWithVM",empVM);
        }

        public IActionResult Index()
        {
            List<Employee> empsListModel = context.Employee.ToList();
            return View("Index", empsListModel);
        }
        //Employee/Edit/1
        public IActionResult Edit(int id)
        {
            //get 
            Employee EmpModel= context.Employee.FirstOrDefault(e => e.Id == id);
            //create
            EmployeeWithDeptListViewModel EmpVm = 
                new EmployeeWithDeptListViewModel();
            //Map
            EmpVm.Name = EmpModel.Name;
            EmpVm.Id = EmpModel.Id; 
            EmpVm.Salary = EmpModel.Salary;
            EmpVm.Address = EmpModel.Address;
            EmpVm.jobTitle = EmpModel.jobTitle;
            EmpVm.DepartmentId = EmpModel.DepartmentId;
            EmpVm.ImageURl = EmpModel.ImageURl;
          //-------------------------------------------
            EmpVm.Departments = context.Department.ToList();

            //view Edit
            return View("Edit", EmpVm);//View Edit ,Model = EmployeeWithDeptListViewModel
        }
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel empvm)
        {
            if(empvm.Name!=null)
            {
                Employee EmpModel =
                    context.Employee.FirstOrDefault(e => e.Id == empvm.Id);
                EmpModel.Name = empvm.Name;
                EmpModel.Salary = empvm.Salary;
                EmpModel.DepartmentId = empvm.DepartmentId;
                EmpModel.jobTitle = empvm.jobTitle;
                EmpModel.ImageURl = empvm.ImageURl;
                EmpModel.Address = empvm.Address;
                //  context.Employee.Update(EmpModel);
                //map 
                //context.Update(empvm);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            empvm.Departments=context.Department.ToList();
            return View("Edit", empvm);
        }
    }
}
