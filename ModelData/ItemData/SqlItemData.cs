using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.ItemData
{
    public class SqlItemData : IItemData
    {
        private PointOfSaleContext context;
        public SqlItemData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Item AddItem(Item item)
        {
            item.id = Guid.NewGuid();
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }

        public void DeleteItem(Guid id)
        {
            context.Items.Remove(GetItem(id));
            context.SaveChanges();
        }

        public Item EditItem(Item item)
        {
            var existing = context.Items.Find(item.id);
            existing.name = item.name;
            existing.price = item.price;
            existing.taxablePercent = item.taxablePercent;
            existing.rating = item.rating;
            existing.description = item.description;
            existing.discountId = item.discountId;
            context.Items.Update(existing);
            context.SaveChanges();
            return item;
        }

        public Item GetItem(Guid id)
        {
            return context.Items.Find(id);
        }

        public List<Item> GetItems()
        {
            return context.Items.ToList();
        }
    }
}
