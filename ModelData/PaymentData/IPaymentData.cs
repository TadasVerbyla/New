using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.PaymentData
{
    public interface IPaymentData
    {
        List<Payment> GetPayments();
        Payment GetPayment(Guid id);
        Payment AddPayment(Payment payment);
        void DeletePayment(Guid id);
        Payment EditPayment(Payment payment);
    }
}
