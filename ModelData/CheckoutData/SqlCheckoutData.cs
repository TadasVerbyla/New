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
            throw new NotImplementedException();
        }

        public Checkout EditCheckout(Checkout checkout)
        {
            throw new NotImplementedException();
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
