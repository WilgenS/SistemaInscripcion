using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeInscripcion.Models
{
    public class LoginRequest
    {
        public string nombre_usuario { get; set; }
        public string contraseña { get; set; }
    }
}