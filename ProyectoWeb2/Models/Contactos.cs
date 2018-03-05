using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb2.Models
{
    public class Contactos
    {    public int id { set; get; }
         public string nombre { set; get; }
         public string  apellidos { set; get; }
         public string Correo_electrónico { set; get; }
         public string Número_telefónico { set; get; }
         public string  Puesto { set; get; }
         public virtual Clientes Cliente { set; get; }
         public int Clienteid { set; get; }

         public Contactos() {

        }
    }
}
