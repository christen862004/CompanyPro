using CompanyPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyPro.Controllers
{
    //Class (catch request -model -view)
    public class HomeController : Controller
    {
        /*
         Method (action) ==>Endpoitn
            1- Must be public
            2- Can't be Static
            3- Can't be Overload
         */
        //action(Method) endpoint url "Home/First"
        //public string First()//Endpoint
        //{
        //    return "---- First ----";
        //}

        public ContentResult ShowMsg()
        {
            //logic 
            //DEcalre
            ContentResult result = new ContentResult();
            //set
            result.Content = "Hello From MVC";
            //return
            return result;
        }
        //retsurn view
        //EP:/Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            //DEcalre
            ViewResult result = new ViewResult();
            //set
            result.ViewName = "MyView";
            //return
            return result;
        }

        //Action (View | Content)
        //home/showmix/133?stdId=10&name=ahmed        //Query string
        public ActionResult  ShowMix(int stdId,string name,int id)
        {
            if (stdId == 12)
            {
                //logiv
                return View("myView");
            }
            else
            {
                //logic
                return Content("Sorry Closed Now!!! :(");
            }
        }



       

        /*
         action can return 
        1)Content  ==>ContentResult
        2)View     ==>ViewREsult
        3)json     ==>JsonREsult
        4)File     ==>FileREsult
        5)Empty    ==>EmptyREsult
        6)NotFound ==>NotFoundREsult
        7)unauth   ==>UnauthorResutl
        .....
         */


        ////HOME/sEcond
        //public string Second()//Endpoint
        //{
        //    return "---- Secode ----";
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //home/privacy
        public IActionResult Privacy()
        {
            return View();
        }
        //home/first
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
