using JobTrackingProject.Entities.Concrete.Payment;

namespace JobTrackingProject.DTO.PaymentDTO
{
    public class PaymentDTO
    {
        public CardModel CardModel { get; set; }
        public AddressModel AddressModel { get; set; }
        public BasketModel BasketModel { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public int Installment { get; set; }
    }
}
