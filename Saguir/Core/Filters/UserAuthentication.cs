using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Saguir.Core.Filters
{
    public class UserAuthentication : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Se comprueba que exista sessión
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["Token"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //Si no existe se envía a la vista de login
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Auth/Index");
            }
        }
    }
}