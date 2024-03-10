using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyPro.Filtters
{
    public class ValidationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Empty
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.ModelState.
        }
    }
}
