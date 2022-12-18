using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.CheckoutData
{
    public class SqlCheckoutData : ICheckoutData
    {
        private PointOfSaleContext context;
        public SqlCheckoutData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Checkout AddCheckout(Checkout checkout)
        {
            checkout.id = Guid.NewGuid();
            context.Checkouts.Add(checkout);
            context.SaveChanges();
            return checkout;
        }

        public void DeleteCheckout(Guid id)
        {
            context.Checkouts.Remove(GetCheckout(id));
            context.SaveChanges();
        }

        public Checkout EditCheckout(Checkout checkout)
        {
            var existing = context.Checkouts.Find(checkout.id);
            existing.employeeId = checkout.employeeId;
            existing.paymentMethod = checkout.paymentMethod;
            existing.customerId = checkout.customerId;
            existing.paymentMethod = checkout.paymentMethod;
            existing.tip = checkout.tip;
            existing.totalAmount = checkout.totalAmount;
            context.Checkouts.Update(existing);
            context.SaveChanges();
            return checkout;
        }

        public Checkout GetCheckout(Guid id)
        {
            return context.Checkouts.Find(id);
        }

        public List<Checkout> GetCheckouts()
        {
            return context.Checkouts.ToList();
        }
    }
}
