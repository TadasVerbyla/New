using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.CheckoutData
{
    public interface ICheckoutData
    {
        List<Checkout> GetCheckouts();
        Checkout GetCheckout(Guid id);
        Checkout AddCheckout(Checkout checkout);
        void DeleteCheckout(Guid id);
        Checkout EditCheckout(Checkout checkout);
    }
}
