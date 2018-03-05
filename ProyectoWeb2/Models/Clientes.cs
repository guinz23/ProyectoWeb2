using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb2.Models
{
    public class Clientes
    {
        public int id { set; get; }
        public string Nombre { set; get; }
        public string cedula_Juridica { set; get; }
        public string pagina_Web { set; get; }
        public string direccion_Fisica { set; get; }
        public string telefono { set; get; }
        public string sector { set; get; }
        public Clientes() {
        }
    }
}
