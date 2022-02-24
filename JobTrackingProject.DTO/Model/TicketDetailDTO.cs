using JobTrackingProject.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProject.DTO.Model
{
    public class TicketDetailDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int TicketId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Products> Products { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string AddressDescription { get; set; }
        public DateTime? TechnicianDate { get; set; }
        public DateTime? TicketOverDate { get; set; }
        public List<ProductSelectDTO> SelectedProducts { get; set; }

    }
}
