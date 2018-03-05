using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb2.Models
{
    public class Support_Tickets
    {
        public int id { set; get; }
        public string Título_Problema { set; get; }
        public string Detalle_del_problema { set; get; }
        public string Quién_reporta_el_problema { set; get; }
        public virtual Clientes Cliente { set; get; }
        public int Clienteid { set; get; }
        public string Estado_actual { set; get; }

        public Support_Tickets() {

        }
    }
}
