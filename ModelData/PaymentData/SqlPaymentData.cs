using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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

        public Payment AddPayment(PaymentDTO payment)
        {
            Payment _payment = new Payment();
            _payment.customerId = (Guid)payment.customerId;
            _payment.employeeId = (Guid)payment.employeeId;
            _payment.orderId = (Guid)payment.orderId;
            _payment.payedOn = (DateTime)payment.payedOn;
            _payment.paymentMethod = payment.paymentMethod;
            _payment.serviceFee = (double)payment.serviceFee;
            _payment.tip = (double)payment.tip;
            _payment.totalAmount = (double)payment.totalAmount;
            _payment.id = Guid.NewGuid();
            context.Payments.Add(_payment);
            context.SaveChanges();
            return _payment;
        }

        public void DeletePayment(Guid id)
        {
            context.Payments.Remove(GetPayment(id));
            context.SaveChanges();
        }

        public Payment EditPayment(Guid id, PaymentDTO payment)
        {
            var existing = context.Payments.Find(id);
            existing.employeeId = (Guid)payment.employeeId;
            existing.paymentMethod = payment.paymentMethod;
            existing.customerId = (Guid)payment.customerId;
            existing.paymentMethod = payment.paymentMethod;
            existing.tip = (double)payment.tip;
            existing.totalAmount = (double)payment.totalAmount;
            context.Payments.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Payment PatchPayment(Guid id, PaymentDTO customer)
        {
            var existing = context.Payments.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Payment>(existing, customer);
                context.Payments.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
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
