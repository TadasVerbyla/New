using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.OrderData
{
    public class SqlOrderData : IOrderData
    {
        private PointOfSaleContext context;
        public SqlOrderData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Order AddOrder(OrderDTO order)
        {
            Order _order = new Order();
            _order.id = order.id;
            _order.customerId = order.customerId;
            _order.businessId = order.businessId;
            _order.discountId = order.discountId;
            _order.status = order.status;
            _order.price = order.price;
            _order.createdOn = order.createdOn;
            _order.completedOn = order.completedOn;
            _order.comments = order.comments;
            _order.deliveryAddress = order.deliveryAddress;
            context.Orders.Add(_order);
            context.SaveChanges();
            return _order;
        }

        public void DeleteOrder(Guid id)
        {
            context.Orders.Remove(GetOrder(id));
            context.SaveChanges();
        }

        public Order EditOrder(Order order)
        {
            var existing = context.Orders.Find(order.id);
            existing.customerId = order.customerId;
            existing.businessId = order.businessId;
            existing.status = order.status;
            existing.price = order.price;
            existing.createdOn = order.createdOn;
            existing.completedOn = order.completedOn;
            existing.comments = order.comments;
            existing.discountId = order.discountId;
            existing.deliveryAddress = order.deliveryAddress;
            context.Orders.Update(existing);
            context.SaveChanges();
            return order;
        }

        public Order GetOrder(Guid id)
        {
            return context.Orders.Find(id);
        }

        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
    }
}
