using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobTrackingProject.DTO.Model;

namespace JobTrackingProject.BusinessLayer.Services.Interface
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}
