using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthJWT.MiddleWares.Attributes
{
    public class PrimerAtributo : ActionFilterAttribute
    {
        private readonly string campo;
        private readonly IHttpContextAccessor _httpContextAccessor;

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
