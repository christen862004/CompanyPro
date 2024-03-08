using CompanyPro.Models;
using CompanyPro.Repository;
using CompanyPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    //ControllerFactory
    //IOC - DIP - DI
    public class EmployeeController : Controller
    {
        //  ITIContext context = new ITIContext();
        //DIP (high Class (Controller) base on abstration( interface)
        IEmployeeRepository EmployeeRepository;
        IDepartmentRepository DepartmentRepository;
        //desgin patter :Depency Injection (dont create  but ask)
        //DI
        public EmployeeController(IEmployeeRepository empRepo, IDepartmentRepository depREpo)
        {
            EmployeeRepository = empRepo;
            DepartmentRepository = depREpo;
            
            //EmployeeRepository = new EmployeeRepository();
            //DepartmentRepository = new DepartmentRepository();
        }



        public IActionResult EmpCardPartial(int id)
        {
            Employee emp = EmployeeRepository.Get(id);
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
            ViewData["Depts"] = DepartmentRepository.GetAll();
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
                    EmployeeRepository.Insert(Emp);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    //send ex message to view as error inside modelstate
                    ModelState.AddModelError("DepartmentId", "Please Select Department");
                    //ModelState.AddModelError("", ex.Message);
                   // ModelState.AddModelError("", ex.InnerException.Message);
                }
            }

            ViewData["Depts"] = DepartmentRepository.GetAll();
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
            Employee EmpModel = EmployeeRepository.Get(id);
            return View("Details",EmpModel);
        }
        public IActionResult Delete(int id)
        {
            Employee EmpModel = EmployeeRepository.Get(id);
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
            Employee EmpModel = EmployeeRepository.Get(id);

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
            List<Employee> empsListModel = EmployeeRepository.GetAll();
            return View("Index", empsListModel);
        }






        //Employee/Edit/1
        public IActionResult Edit(int id)
        {
            //get 
            Employee EmpModel= EmployeeRepository.Get(id);
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
            EmpVm.Departments =DepartmentRepository.GetAll();

            //view Edit
            return View("Edit", EmpVm);//View Edit ,Model = EmployeeWithDeptListViewModel
        }
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel empvm)
        {
            if(empvm.Name!=null)
            {
                //mapping wrong
                Employee EmpModel =  EmployeeRepository.Get(empvm.Id);
                EmployeeRepository.Update(EmpModel);
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            
            empvm.Departments=DepartmentRepository.GetAll();
            return View("Edit", empvm);
        }
    }
}
