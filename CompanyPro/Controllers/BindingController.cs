using CompanyPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class BindingController : Controller
    {
        //Binding PRimitive type (
        //Binding/TestPrimitive?name=ahme&age=12&id=11
        //Binding/TestPrimitive/11?name=ahme&age=12&color[1]=red&color[0]=blue
        public IActionResult TestPrimitive
            (int age,string name,int id, string[] color)
        {
            
            return Content($"{name} \t {age}");
        }

        //bind Collection (list ,Dictionary)
        //Binding/TestDic?Phones[Ahmed]=123&Phones[Christen]=456&name=ITI
        public IActionResult TestDic(Dictionary<string,string> Phones,string name)
        {
            return Content("Ok");
        }

        //Complex/Cutome Type(Class)
        //Map url parameter ==>obj Property
        //Binding/TestObj?id=1&name=sd&ManagerName=Hala&Emps[0].Salary=5000
        public IActionResult TestObj(Department dept)//,int id,string name,string managername)
        {
            //saveing
            return Content("Ok");

        }
    }
}
