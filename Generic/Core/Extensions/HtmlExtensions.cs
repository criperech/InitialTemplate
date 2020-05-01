using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saguir.Core.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString ToJson(this HtmlHelper helper, Object obj)
        {
            //Convertimos el modelo en un string
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None);

            //Remplazamos los caracteres que dañan el json https://www.json.org/
            var fix = json.Replace("\\", "\\\\")
                          .Replace("\\t", "     ")
                          .Replace("\\f", "")
                          .Replace("\\b", "")
                          .Replace("\\f", "")
                          .Replace("\\r", "<br>")
                          .Replace("\\n", "<br>")
                          .Replace("\\r\\n", "<br>")
                          .Replace("`", "");

            //Retornamos la cadena con la correción
            return helper.Raw(fix);
        }
    }
}