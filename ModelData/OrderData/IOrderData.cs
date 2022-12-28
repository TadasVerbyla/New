using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.OrderData
{
    public interface IOrderData
    {
        List<Order> GetOrders();
        Order GetOrder(Guid id);
        Order AddOrder(Order order);
        void DeleteOrder(Guid id);
        Order EditOrder(Order order);
    }
}
