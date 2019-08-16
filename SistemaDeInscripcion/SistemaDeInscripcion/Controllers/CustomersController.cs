using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaDeInscripcion.Controllers
{
    [Authorize]
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var customerFake = "customer-fake";
            return Ok(customerFake);

        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customerFake = new string[] { "customer-1", "customer-2", "customer-3" };
            return Ok(customerFake);
        }
    }
}
