using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
