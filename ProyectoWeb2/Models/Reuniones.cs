using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb2.Models
{
    public class Reuniones
    {
        public int id { set; get; }
        public string Título_reunión { set; get; }
        [Display(Name = "Fecha_Hora ")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Hora { get; set; }
        public virtual Usuarios Usuario { set; get; }
        public int Usuarioid { set; get; }
        public virtual Clientes Cliente { set; get; }
        public int Clienteid { set; get; }

        public Reuniones() {

        }
    }
}
