using Microsoft.EntityFrameworkCore;

namespace AppGymWeb.Models
{
    public class GymContext : DbContext
    {

        public DbSet<Cliente> Clientes {  get; set; }
        public DbSet<Plan> Planes { get; set; }

        public DbSet<Actividad> Actividades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LUCAS\\SQLEXPRESS;Initial Catalog=AppGymWeb;" +
                " Integrated Security= true; TrustServerCertificate= true; Encrypt= true");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
