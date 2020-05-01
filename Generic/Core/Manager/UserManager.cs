using ModelStructure.Core.Misc;
using System.Web;

namespace Saguir.Core.Manager
{
    public static class UserManager
    {

        /// <summary>
        /// Método encargado de crear los datos de sessión
        /// </summary>
        /// <param name="userdata"></param>
        public static void StartSession(UserApp userdata, HttpContextBase context)
        {
            context.Session["Token"] = userdata.Token;
        }

        /// <summary>
        /// Retorna vacio o el token si se encuentra logueado el user
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentToken(HttpContext context) => (context.Session["Token"] != null) ? context.Session["Token"].ToString() : string.Empty;

    }
}