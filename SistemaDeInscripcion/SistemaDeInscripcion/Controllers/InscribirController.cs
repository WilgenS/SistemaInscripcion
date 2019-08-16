using SistemaDeInscripcion.Datos.Modelo;
using SistemaDeInscripcion.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaDeInscripcion.Controllers
{
    public class InscribirController : ApiController
    {
        CursosEntities BD = new CursosEntities();
        InscribirEntities DB = new InscribirEntities();
        [HttpGet]
        public IEnumerable<cursos> Get()
        {
            var Listado = BD.cursos.ToList();
            return Listado;
        }

        [HttpGet]
        public cursos Get(int id)
        {
            var curso = BD.cursos.FirstOrDefault(x => x.id_curso == id);
            return curso;
        }

        [HttpPost]
        public bool Post (inscripcion inscripcion)
        {
            DB.inscripcion.Add(inscripcion);
            return BD.SaveChanges() > 0;
        }
    }
}
