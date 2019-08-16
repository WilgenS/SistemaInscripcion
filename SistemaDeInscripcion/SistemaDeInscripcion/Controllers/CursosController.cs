using Newtonsoft.Json;
using SistemaDeInscripcion.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeInscripcion.Controllers
{
    public class CursosController : Controller
    {
        // GET: Cursos
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:49764/";
            List<cursos> EmpInfo = new List<cursos>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
                //Llamar usuarios usando Http
                HttpResponseMessage Res = await client.GetAsync("Api/Inscribir/");
                if (Res.IsSuccessStatusCode)
                {
                    //Entra y asigna datos
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Almacena datos 
                    EmpInfo = JsonConvert.DeserializeObject<List<cursos>>(EmpResponse);

                }
                //Muestra la lista de usuarios
                return View(EmpInfo);
            }

        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49764/");
            var request = client.GetAsync("api/Inscribir?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var ResultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<cursos>(ResultString);
                return View(informacion);
            }

            return View();
        }
    }
}