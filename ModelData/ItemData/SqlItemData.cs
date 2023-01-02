using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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

        public Item AddItem(ItemDTO item)
        {
            Item _item = new Item();
            _item.description = item.description;
            _item.discountId = (Guid)item.discountId;
            _item.name = item.name;
            _item.price = (decimal)item.price;
            _item.rating = (float)item.rating;
            _item.taxablePercent = (decimal)item.taxablePercent;
            _item.id = Guid.NewGuid();
            context.Items.Add(_item);
            context.SaveChanges();
            return _item;
        }

        public void DeleteItem(Guid id)
        {
            context.Items.Remove(GetItem(id));
            context.SaveChanges();
        }

        public Item EditItem(Guid id, ItemDTO item)
        {
            var existing = context.Items.Find(id);
            existing.name = item.name;
            existing.price = (decimal)item.price;
            existing.taxablePercent = (decimal)item.taxablePercent;
            existing.rating = (float)item.rating;
            existing.description = item.description;
            existing.discountId = (Guid)item.discountId;
            context.Items.Update(existing);
            context.SaveChanges();
            return existing;
        }
        public Item PatchItem(Guid id, ItemDTO customer)
        {
            var existing = context.Items.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Item>(existing, customer);
                context.Items.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
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
