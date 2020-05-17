using CrudEntityFramework.Models;//importar modelos
using Microsoft.EntityFrameworkCore;//debemos importar para utilizar DbContext


namespace CrudEntityFramework.Data
{
    public class AplicationDbContext : DbContext // : heredar
    {
        //metodo constructor
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        //vamos a usar el modelo Usuario
        public DbSet<Usuario> Usuario { get; set; }
        /*Nota: si tenemos mas tablas, aqui las agregamos
         * public DbSet<Categoria> Categoria { get; set; }*/
    }
}
