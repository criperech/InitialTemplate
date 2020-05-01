using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace AuthJWT.MiddleWares.Filters
{
    public class PrimerFIltro : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("PrimerFIltro : OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("PrimerFIltro : OnActionExecuting");
        }
    }
}
