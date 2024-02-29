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
    }
}
