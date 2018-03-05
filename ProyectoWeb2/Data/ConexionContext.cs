using Microsoft.EntityFrameworkCore;
using ProyectoWeb2.Models;

namespace ProyectoWeb2
{
    public class ConexionContext: DbContext
    {
        public ConexionContext(DbContextOptions<ConexionContext> options)
           : base(options)
        {
        }
        public DbSet<ProyectoWeb2.Models.Usuarios> Usuarios { get; set; }
        public DbSet<ProyectoWeb2.Models.Clientes> Clientes { get; set; }
        public DbSet<ProyectoWeb2.Models.Contactos> Contactos { get; set; }
        public DbSet<ProyectoWeb2.Models.Reuniones> Reuniones { get; set; }
        public DbSet<ProyectoWeb2.Models.Support_Tickets> Support_Tickets { get; set; }
        
     
   
   

    }
}