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
        public DbSet<Course> Courses { set; get; }
        public DbSet<Address> Addresses { set; get; }
        public DbSet<AngularDemo.Models.College> College { get; set; }

        //AGREGAR LISTAS QUE DESEO USAR
    }
}
