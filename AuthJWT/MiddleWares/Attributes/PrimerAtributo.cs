using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.MiddleWares.Attributes
{
    public class PrimerAtributo : ActionFilterAttribute
    {
        private readonly string campo;
        private IHttpContextAccessor _httpContextAccessor;

        public PrimerAtributo(IHttpContextAccessor ihttpContextAccessor)
        {
            this._httpContextAccessor = ihttpContextAccessor;
            this.campo = "asdasd";
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {

            var z = this._httpContextAccessor;

            base.OnResultExecuting(context);
        }
    }
}
