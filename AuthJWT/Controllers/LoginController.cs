using AuthJWT.DataAccess.Models;
using AuthJWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelStructure.Core.Misc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICoreModel modelDbContext;
        readonly IConfiguration configSystem;

        public LoginController(IConfiguration configuration, ICoreModel coreModel)
        {
            this.configSystem = configuration;
            this.modelDbContext = coreModel;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var resultUser = new UserApp();

            //Login logic (user - password)


            resultUser.Login = true;
            resultUser.Token = this.BuildToken(username, "Administrator").Token;

            return Ok(resultUser);
        }

        /// <summary>
        /// Método para crear un Token Encriptado
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rol"></param>
        /// <returns></returns>
        private UserToken BuildToken(string idUser, string rol)
        {

            //Creamos las Claims personalizadas
            var claimsData = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.UniqueName, idUser),
                new Claim("Custom", "CustomData"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //Claim para determinar el Rol
                new Claim(ClaimTypes.Role, rol)
            };


            //Creamos las llaves de cifrado y las llaves de encriptamiento
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configSystem["JWTConfiguration:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var encryptingCredentials = new EncryptingCredentials(key, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);

            //Setteamos el tiempo de expiracion
            var tiempoExpiracion = DateTime.UtcNow.AddMinutes(30);

            //Asignamos el payload y la firma que tendrá el token
            var token = new JwtSecurityTokenHandler().CreateJwtSecurityToken(
                issuer: null,
                audience: null,
                subject: new ClaimsIdentity(claimsData),
                notBefore: null,
                expires: tiempoExpiracion,
                issuedAt: null,
                signingCredentials: creds,
                encryptingCredentials: encryptingCredentials
                );

            //Creamos la clase de retorno
            return new UserToken()
            {
                ExpirationToken = tiempoExpiracion,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }

    }


}