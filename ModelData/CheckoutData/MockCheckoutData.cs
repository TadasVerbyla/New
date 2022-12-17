using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.CheckoutData
{
    public class MockCheckoutData : ICheckoutData
    {
        private List<Checkout> checkouts = new List<Checkout>()
        {
            new Checkout()
            {
                id = Guid.NewGuid(),
                paymentMethod = "credit card"
            },
            new Checkout()
            {
                id = Guid.NewGuid(),
                paymentMethod = "cash"
            }
        };

        public Checkout AddCheckout(Checkout checkout)
        {
            checkout.id = Guid.NewGuid();
            checkouts.Add(checkout);
            return checkout;
        }

        public void DeleteCheckout(Guid id)
        {
            checkouts.Remove(GetCheckout(id));
        }

        public Checkout EditCheckout(Checkout checkout)
        {
            var existing = GetCheckout(checkout.id);
            existing.employeeId = checkout.employeeId;
            existing.paymentMethod = checkout.paymentMethod;
            existing.customerId = checkout.customerId;
            existing.paymentMethod = checkout.paymentMethod;
            existing.tip = checkout.tip;
            existing.totalAmount = checkout.totalAmount;
            return existing;
        }

        public Checkout GetCheckout(Guid id)
        {
            return checkouts.SingleOrDefault(x => x.id == id);
        }

        public List<Checkout> GetCheckouts()
        {
            return checkouts;
        }
    }
}
