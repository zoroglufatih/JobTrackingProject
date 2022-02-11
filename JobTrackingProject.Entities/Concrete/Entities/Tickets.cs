using JobTrackingProject.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProject.Entities.Concrete.Entities
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Categories Categories { get; set; }

    }
}
