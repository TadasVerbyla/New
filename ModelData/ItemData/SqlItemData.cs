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

        public Item AddItem(ItemDTO item)
        {
            Item _item = new Item();
            _item.description = item.description;
            _item.discountId = item.discountId;
            _item.name = item.name;
            _item.price = item.price;
            _item.rating = item.rating;
            _item.taxablePercent = item.taxablePercent;
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
            existing.price = item.price;
            existing.taxablePercent = item.taxablePercent;
            existing.rating = item.rating;
            existing.description = item.description;
            existing.discountId = item.discountId;
            context.Items.Update(existing);
            context.SaveChanges();
            return existing;
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
