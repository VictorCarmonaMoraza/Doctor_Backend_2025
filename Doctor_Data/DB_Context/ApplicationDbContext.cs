using Doctor_Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Data.DB_Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //Con los nombre en plural es como se crearan las tablas en la base de datos
        public DbSet<User> Users { get; set; }
    }
}
