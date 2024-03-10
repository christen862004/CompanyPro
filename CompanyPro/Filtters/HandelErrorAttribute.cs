using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyPro.Filtters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult result = new ViewResult();
            result.ViewName = "Error";
            //result.Model = context.Exception;
            context.Result = result;
        }
    }
}
