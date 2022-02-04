using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
    }
}
