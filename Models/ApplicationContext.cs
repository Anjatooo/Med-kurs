using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApplication3.Models

{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Doc> Docs { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated(); - с ней не работают миграции
        }
    }
}
