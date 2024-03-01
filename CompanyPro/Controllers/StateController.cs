using Microsoft.AspNetCore.Mvc;

namespace CompanyPro.Controllers
{
    public class StateController : Controller
    {
        //State MAnagement USing Session (server side)
        public IActionResult SetSession()
        {
            //conver obj ==>json send as string

            //logic
            //save info server 
            HttpContext.Session.SetString("Name", "islam");
            HttpContext.Session.SetInt32("NoOfTrainee", 30);

            //logic
            return Content("Data Saved");
        }

        public IActionResult GetSession()
        {
            //logic
            //read session
            string n= HttpContext.Session.GetString("Name");
            int count= HttpContext.Session.GetInt32("NoOfTrainee").Value;
            //logic
            
            return Content($"Get Data name= {n} \t count ={count}");
        }

        //State Managemnt using Cookie (Client Side)
        public IActionResult SetCookie()
        {
            //logic
            int count = 10;
            //Store Cookie from server to client (response)
            CookieOptions cookieOption= new CookieOptions();
            cookieOption.Expires = DateTime.Now.AddDays(4);

            HttpContext.Response.Cookies.Append("Name","Abeer");//session cookie
            HttpContext.Response.Cookies.Append("Count", count.ToString(),cookieOption);//Presistent Cookie
            return Content("Cookie SAved");
        }
        public IActionResult GetCookie()
        {
            //logic
            //server read cookie from client (request)
           string? n= HttpContext.Request.Cookies["Name"];
           string? c = HttpContext.Request.Cookies["Count"];
           return Content($"Get Data From Cookie name={n} \n count={c}");
        }
        #region for test
        //int count;
        //public StateController()
        //{
        //    count = 0;
        //}

        ////State/increament  1
        ////state/increnemr   1
        //public IActionResult increament()
        //{
        //    count++;
        //    return Content(count.ToString());
        //}
        #endregion
    }
}
