using Mi_primer_API.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Mi_primer_API.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        //seccion para crear el Dbset de las entidades o modelo
        public DbSet<Category> Categories { get; set; }

        //public DbSet<Movie> Movies { get; set; }

    }
}
