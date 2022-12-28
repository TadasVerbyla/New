using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.ItemData
{
    public interface IItemData
    {
        List<Item> GetItems();
        Item GetItem(Guid id);
        Item AddItem(Item item);
        void DeleteItem(Guid id);
        Item EditItem(Item item);
    }
}
