using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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
            _discount.amount = (double)discount.amount;
            _discount.code = discount.code;
            _discount.discount = (DiscountType)discount.discount;
            _discount.name = discount.name;
            _discount.percentage = (bool)discount.percentage;
            _discount.validFrom = (DateTime)discount.validFrom;
            _discount.validTo = (DateTime)discount.validTo;
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
            existing.amount = (double)discount.amount;
            existing.percentage = (bool)discount.percentage;
            existing.discount = (DiscountType)discount.discount;
            existing.code = discount.code;
            existing.validFrom = (DateTime)discount.validFrom;
            existing.validTo = (DateTime)discount.validTo;
            context.Discounts.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Discount PatchDiscount(Guid id, DiscountDTO discount)
        {
            var existing = context.Discounts.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Discount>(existing, discount);
                context.Discounts.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
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
