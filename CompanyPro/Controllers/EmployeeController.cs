using CompanyPro.Models;
using CompanyPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        


        public IActionResult EmpCardPartial(int id)
        {
            Employee emp = context.Employee.FirstOrDefault(e => e.Id == id);
            //return partial
            return PartialView("_EmployeeCardPartial",emp);//view =_EmployeeCardPartial ,Model=
        }





        //Employee/CheckSalary?Salary=1000&JobTitle=Instructor
        public IActionResult CheckSalary(int Salary,string jobTitle)
        {
            //logic db - business
            if (Salary > 6000 && jobTitle == "Instructor")
                return Json(true);
            else if(Salary > 10000 && jobTitle == "Manager")
                return Json(true);
            return Json(false);
        }

        //press link
        public IActionResult New()
        {
            //Employee(Model) +List<department>   ==>ViewDta -viewbag -viewModel
            ViewData["Depts"] = context.Department.ToList();
            return View("New");
        }

        //click on submit button
        [HttpPost]
        public IActionResult SaveNEw(Employee  Emp)
        {
            //if(Emp.Name!=null && Emp.Salary > 6000)
            if(ModelState.IsValid==true)//C#
            {
                try
                {
                    context.Add(Emp);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    //send ex message to view as error inside modelstate
                    ModelState.AddModelError("DepartmentId", "Please Select Department");
                    //ModelState.AddModelError("", ex.Message);
                   // ModelState.AddModelError("", ex.InnerException.Message);
                }
            }

            ViewData["Depts"] = context.Department.ToList();
            return View("New", Emp);
        }

        public IActionResult DEtails(int id,int age)
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
        public IActionResult Delete(int id)
        {
            Employee EmpModel = context.Employee.FirstOrDefault(e => e.Id == id);
            return View("Delete", EmpModel);
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
