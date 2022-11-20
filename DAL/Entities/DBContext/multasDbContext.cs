namespace ActividadSanciones_ASPNET.DAL.Entities.DBContext
{
    using Microsoft.EntityFrameworkCore;
    public class multasDbContext : DbContext
    {
        public multasDbContext(DbContextOptions<multasDbContext> options) :
            base(options)
        {

        }

        public virtual DbSet<matricula> matricula { get; set; }

        public virtual DbSet<conductor> conductor { get; set; }

        public virtual DbSet<sanciones> sanciones { get; set; }

    }
}