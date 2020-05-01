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
    }
}