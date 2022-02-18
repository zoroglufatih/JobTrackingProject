using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProject.Entities.Concrete.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Categories Categories { get; set; }

        public List<TicketProducts> TicketProducts { get; set; }

    }
}
