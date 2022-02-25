using JobTrackingProject.Entities.Concrete.Payment;

namespace JobTrackingProject.BusinessLayer.Services
{
    public interface IPaymentService
    {
        public InstallmentModel CheckInstallments(string binNumber, decimal price);
        public PaymentResponseModel Pay(PaymentModel model);
    }
}
