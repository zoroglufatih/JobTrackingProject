using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobTrackingProject.Entities.Concrete.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(50)]
        [PersonalData]
        public string Name { get; set; }
        [Required, StringLength(50)]
        [PersonalData]
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
