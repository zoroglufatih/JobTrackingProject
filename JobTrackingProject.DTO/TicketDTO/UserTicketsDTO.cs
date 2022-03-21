using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iyzipay.Model.V2.Subscription;
using JobTrackingProject.Entities.Concrete.Entities;

namespace JobTrackingProject.DTO.TicketDTO
{
    public class UserTicketsDTO
    {
        public string UserId { get; set; }
        public string Description { get; set; }
        public List<Products>? ProductsList { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? TechnicianDate { get; set; }
        public DateTime? TicketOverDate { get; set; }
        public double TotalPrice { get; set; }

    }
}
