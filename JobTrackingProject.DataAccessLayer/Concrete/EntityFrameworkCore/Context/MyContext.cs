using System.Security.Cryptography.X509Certificates;
using JobTrackingProject.Entities.Concrete.Entities;
using JobTrackingProject.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context
{
    public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Products>()
                .Property(x => x.Price)
                .HasPrecision(9, 2);
            builder.Entity<TicketProducts>()
                .HasKey(x => new
                {
                    x.TicketId,
                    x.ProductId
                });
            //builder.Entity<TicketProducts>()
            //    .Navigation(x => x.Products)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
            //builder.Entity<TicketProducts>()
            //    .Navigation(x => x.Tickets)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketProducts> TicketProducts { get; set; }
    }
}
