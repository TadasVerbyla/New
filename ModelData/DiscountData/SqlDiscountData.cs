using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.DiscountData
{
    public class SqlDiscountData : IDiscountData
    {
        private PointOfSaleContext context;
        public SqlDiscountData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Discount AddDiscount(Discount discount)
        {
            discount.id = Guid.NewGuid();
            context.Discounts.Add(discount);
            context.SaveChanges();
            return discount;
        }

        public void DeleteDiscount(Guid id)
        {
            context.Discounts.Remove(GetDiscount(id));
            context.SaveChanges();
        }

        public Discount EditDiscount(Discount discount)
        {
            var existing = context.Discounts.Find(discount.id);
            existing.name = discount.name;
            existing.amount = discount.amount;
            existing.percentage = discount.percentage;
            existing.discount = discount.discount;
            existing.code = discount.code;
            existing.validFrom = discount.validFrom;
            existing.validTo = discount.validTo;
            context.Discounts.Update(existing);
            context.SaveChanges();
            return discount;
        }

        public Discount GetDiscount(Guid id)
        {
            return context.Discounts.Find(id);
        }

        public List<Discount> GetDiscounts()
        {
            return context.Discounts.ToList();
        }
    }
}
