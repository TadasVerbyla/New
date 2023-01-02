using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.PaymentData
{
    public interface IPaymentData
    {
        List<Payment> GetPayments();
        Payment GetPayment(Guid id);
        Payment AddPayment(PaymentDTO payment);
        void DeletePayment(Guid id);
        Payment EditPayment(Guid id, PaymentDTO payment);
        Payment PatchPayment(Guid id, PaymentDTO payment);
    }
}
