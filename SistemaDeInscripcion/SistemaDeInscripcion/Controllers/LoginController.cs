using SistemaDeInscripcion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SistemaDeInscripcion.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($"Principal-user:{identity.Name}-IsAuthenticated:{identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            bool isCredentialValid = (login.contraseña == "123");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.nombre_usuario);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
