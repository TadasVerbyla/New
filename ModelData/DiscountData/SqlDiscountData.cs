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

        public Discount AddDiscount(DiscountDTO discount)
        {
            Discount _discount = new Discount();
            _discount.amount = discount.amount;
            _discount.code = discount.code;
            _discount.discount = discount.discount;
            _discount.name = discount.name;
            _discount.percentage = discount.percentage;
            _discount.validFrom = discount.validFrom;
            _discount.validTo = discount.validTo;
            _discount.id = Guid.NewGuid();
            context.Discounts.Add(_discount);
            context.SaveChanges();
            return _discount;
        }

        public void DeleteDiscount(Guid id)
        {
            context.Discounts.Remove(GetDiscount(id));
            context.SaveChanges();
        }

        public Discount EditDiscount(Guid id, DiscountDTO discount)
        {
            var existing = context.Discounts.Find(id);
            existing.name = discount.name;
            existing.amount = discount.amount;
            existing.percentage = discount.percentage;
            existing.discount = discount.discount;
            existing.code = discount.code;
            existing.validFrom = discount.validFrom;
            existing.validTo = discount.validTo;
            context.Discounts.Update(existing);
            context.SaveChanges();
            return existing;
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
