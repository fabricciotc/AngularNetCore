using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDemo.Models;

namespace AngularDemo.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {       
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
                
            }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<User>())
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    // Possibly check for null or if it's changed at all.
                    entry.Entity.FirstName = entry.Entity.FirstName.ToUpper();
                    entry.Entity.LastNames = entry.Entity.LastNames.ToUpper();
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Address> Addresses { set; get; }

        //AGREGAR LISTAS QUE DESEO USAR
    }
}
