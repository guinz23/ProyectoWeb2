using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb2.Models
{
    public class Usuarios
    {
        public int id { set; get; }
        public string usuario { set; get; }
        public string correo { set; get; }
        public string contraseña { set; get; }
        public string rol {set;get;}

        public Usuarios() {

        }
    }
   
}
