using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication3.Models.Doctor;
using WebApplication3.Models.Users;

namespace WebApplication3.Services.BD

{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Doc> Docs { get; set; } = null!;
        public DbSet<Polyclinic> Polyclinics { get; set; } = null!;
        public DbSet<Speciality> Specialities { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated(); - с ней не работают миграции
        }
    }
}
