using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProject.Entities.Concrete.Entities
{
    public class TicketProducts
    {
        public int TicketId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }

        //[ForeignKey(nameof(ProductId))]
        public List<Products> Products { get; set; }

        //[ForeignKey(nameof(TicketId))]
        public List<Tickets> Tickets { get; set; }
    }
}
