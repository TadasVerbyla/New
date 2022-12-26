using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.PaymentData
{
    public class SqlPaymentData : IPaymentData
    {
        private PointOfSaleContext context;
        public SqlPaymentData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Payment AddPayment(Payment payment)
        {
            payment.id = Guid.NewGuid();
            context.Payments.Add(payment);
            context.SaveChanges();
            return payment;
        }

        public void DeletePayment(Guid id)
        {
            context.Payments.Remove(GetPayment(id));
            context.SaveChanges();
        }

        public Payment EditPayment(Payment payment)
        {
            var existing = context.Payments.Find(payment.id);
            existing.employeeId = payment.employeeId;
            existing.paymentMethod = payment.paymentMethod;
            existing.customerId = payment.customerId;
            existing.paymentMethod = payment.paymentMethod;
            existing.tip = payment.tip;
            existing.totalAmount = payment.totalAmount;
            context.Payments.Update(existing);
            context.SaveChanges();
            return payment;
        }

        public Payment GetPayment(Guid id)
        {
            return context.Payments.Find(id);
        }

        public List<Payment> GetPayments()
        {
            return context.Payments.ToList();
        }
    }
}
