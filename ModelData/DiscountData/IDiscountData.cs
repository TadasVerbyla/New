using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.DiscountData
{
    public interface IDiscountData
    {
        List<Discount> GetDiscounts();
        Discount GetDiscount(Guid id);
        Discount AddDiscount(Discount discount);
        void DeleteDiscount(Guid id);
        Discount EditDiscount(Discount discount);
    }
}
