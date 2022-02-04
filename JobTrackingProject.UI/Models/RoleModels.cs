using System.Collections;
using System.Collections.Generic;

namespace JobTrackingProject.UI.Models
{
    public class RoleModels
    {
        public static string Admin = "Admin";
        public static string Operator = "Admin";
        public static string Technician = "Admin";
        public static string User = "Admin";

        public static ICollection<string> Roles => new List<string>() { Admin, Operator, Technician, User };
    }
}
