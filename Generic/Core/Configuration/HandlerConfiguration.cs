using Newtonsoft.Json;
using Saguir.Core.Configuration.Models;
using System.Configuration;
using System.IO;
using System.Web;

namespace Saguir.Core.Configuration
{
    public static class HandlerConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ConfigurationModel GetConfiguration()
        {

            ConfigurationModel connectionConfig;

            //Comprobamos si ya está en memoria las variables de confi
            if (HttpContext.Current.Application["configuration"] == null)
            {
                //Obtenemos el enviroment actual
                var actualEnviroment = ConfigurationManager.AppSettings["Enviroment"].ToString();

                //Obtenemos la ruta del archivo
                var pathFile = HttpContext.Current.Server.MapPath($"~/Core/Configuration/Connections/{actualEnviroment}.json");
                using (StreamReader r = new StreamReader(pathFile))
                {
                    //Leemos el archivo
                    string json = r.ReadToEnd();
                    //Convertimos el archivo y lo asignamos a la propiedad global
                    connectionConfig = JsonConvert.DeserializeObject<ConfigurationModel>(json);

                    //Guardamos en memoria
                    HttpContext.Current.Application["configuration"] = connectionConfig;
                }
            }
            else
            {
                //Obtenemos el valor de la memoria
                connectionConfig = (ConfigurationModel)HttpContext.Current.Application["configuration"];
            }


            return connectionConfig;
        }


    }
}