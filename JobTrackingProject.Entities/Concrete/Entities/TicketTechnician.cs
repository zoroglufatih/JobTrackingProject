using JobTrackingProject.Entities.Concrete.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackingProject.Entities.Concrete.Entities
{
    public class TicketTechnician
    {
        public int TicketId { get; set; }
        [StringLength(450)]
        public string TechnicianId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Tickets Tickets { get; set; }
        [ForeignKey(nameof(TechnicianId))]
        public ApplicationUser Technician { get; set; }
    }
}
