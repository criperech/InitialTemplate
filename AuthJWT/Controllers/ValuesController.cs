using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelStructure.Core.Misc;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,SuperAdministrador")]
    public class ValuesController : ControllerBase
    {
        private readonly ClaimsPrincipal userManager;
        readonly IConfiguration configSystem;
        public ValuesController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = httpContextAccessor.HttpContext.User;
            this.configSystem = configuration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<TestApi> Get()
        {


            //ASì se debe obtener el enviroment
            return Ok(new TestApi() { CurrentEnviroment = this.configSystem["TestEnviroment"],IdCurrentUser = this.userManager.Identity.Name });

        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
