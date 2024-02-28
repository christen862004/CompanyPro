using CompanyPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult All()
        {
            //ask model
            StudentBL bl = new StudentBL();
            List<Student> StudentsModel= bl.GetAll();

            //send data view
            return View("ShowAll",StudentsModel);//View name=ShowAll ,send Model (List<student>)
        }
        //student/details/1
        //student/details?id=1
        public IActionResult Details(int id)
        {
            StudentBL bl=new StudentBL();
            Student stdModel = bl.GetByID(id);
            return View("DEtails", stdModel);//DEtails ,Model ==Student
        }
    }
}
