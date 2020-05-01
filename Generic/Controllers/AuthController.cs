using ModelStructure.Core.Misc;
using Saguir.Core.Manager;
using Saguir.Core.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saguir.Controllers
{
    public class AuthController : Controller
    {
        private readonly IWebApiCoreService webApi;
        public AuthController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }

        // GET: Auth
        public ActionResult Index(string errorLogin = null)
        {

            return View();
        }


        /// <summary>
        /// `Login
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {

            var resultLogin = await webApi.PostAsync<UserApp>("Login", new { username, password });

            //verificamos la respuesta
            if (resultLogin.Login)
            {
                // Comprobamos si tiene Token  //

                if (!string.IsNullOrEmpty(resultLogin.Token))
                {
                    //Creamos la sesion
                    UserManager.StartSession(resultLogin, HttpContext);

                    return Redirect("~/DashBoard");
                }

            }

            //Retornar con error de login
            return Redirect("~/Auth");

        }
    }
}