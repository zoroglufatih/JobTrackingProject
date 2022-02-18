using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace JobTrackingProject.Entities.Concrete.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Products> Products { get; set; }
        public virtual List<Tickets> Tickets { get; set; }
    }
}
