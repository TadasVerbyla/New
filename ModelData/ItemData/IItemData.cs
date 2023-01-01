using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.ItemData
{
    public interface IItemData
    {
        List<Item> GetItems();
        Item GetItem(Guid id);
        Item AddItem(ItemDTO item);
        void DeleteItem(Guid id);
        Item EditItem(Guid id, ItemDTO item);
    }
}
