using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthJWT.DataAccess.Models;
using AuthJWT.MiddleWares.Attributes;
using AuthJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelStructure.Core;
using ModelStructure.Core.Misc;
using WebApi.DataAccess.DataBase;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICoreModel modelDbContext;
        IConfiguration configSystem;

        public LoginController(IConfiguration configuration, ICoreModel coreModel)
        {
            this.configSystem = configuration;
            this.modelDbContext = coreModel;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var resultUser = new UserApp();

            //Buscamos el usuario en base de datos
            var user = await this.modelDbContext.GetOneAsync<Users>(x => x.UseUserName == username && x.UsePasswordHash == password);

            //Si existe obtenemos los sites a los que pertenece y su respectivo rol
            if (user != null)
            {

                resultUser.Usuario = new ModelStructure.Core.Usuario() {
                    Id = user.UseIdUsuarioPk,
                    FirstName = user.UseFirstName,
                    SecondName = user.UseSecondName,
                    FirstLastName = user.UseFirstLastName,
                    SecondLastName = user.UseSecondName
                };

                //Lista de relaciones de ese usuario con los sites y los roles
                var dataRolUser = this.modelDbContext.Search<UserRolesResidentialSites>(x => x.UrrIdUserFk == user.UseIdUsuarioPk)
                                                     .Include(x => x.UrrIdRolFkNavigation).Include(x=> x.UrrIdResidentialSiteFkNavigation).ToList();

             
                //Obtenemos la info de los sites
                foreach (var dru in dataRolUser)
                {
                    if (dru.UrrIdResidentialSiteFkNavigation != null)
                    {
                        resultUser.SitesWithRol.Add(new UserRolResidentialSite()
                        {
                            IdRol = dru.UrrIdRolFk,
                            RolName = dru.UrrIdRolFkNavigation.RolName,
                            Site = new ResidentialSite()
                            {
                                Id = dru.UrrIdResidentialSiteFkNavigation.RsiIdResidentialPk,
                                Name = dru.UrrIdResidentialSiteFkNavigation.RsiName
                            }
                        });

                    }
                }

               //Si solo tiene un site y un rol le asigna un token directamente
                if (resultUser.SitesWithRol.Count == 1)
                {
                    //Creamosel token
                    var tokenReturned = this.BuildToken(user.UseIdUsuarioPk, resultUser.SitesWithRol.FirstOrDefault().RolName);

                    resultUser.Token = tokenReturned.Token;
                    resultUser.ExpireToken = tokenReturned.ExpirationToken;

                }

            }
            //Solo se aprueba login si se tiene sites asociados
            resultUser.Login = (resultUser.SitesWithRol.Count > 0);

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