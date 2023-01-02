using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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
            _order.customerId = (Guid)order.customerId;
            _order.businessId = (Guid)order.businessId;
            _order.discountId = (Guid)order.discountId;
            _order.status = (OrderStatus)order.status;
            _order.price = (double)order.price;
            _order.createdOn = (DateTime)order.createdOn;
            _order.completedOn = (DateTime)order.completedOn;
            _order.comments = order.comments;
            _order.deliveryAddress = order.deliveryAddress;
            _order.id = Guid.NewGuid();
            _order.items = new List<Item>();
            foreach (Guid itemId in order.itemIds)
            {
                Item i = context.Items.Find(itemId);
                if (i != null)
                {
                    _order.items.Add(i);
                }
            }
            context.Orders.Add(_order);
            context.SaveChanges();
            return _order;
        }

        public Order PatchOrder(Guid id, OrderDTO customer)
        {
            var existing = context.Orders.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Order>(existing, customer);
                context.Orders.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
        }

        public void DeleteOrder(Guid id)
        {
            context.Orders.Remove(GetOrder(id));
            context.SaveChanges();
        }

        public Order EditOrder(Guid id, OrderDTO order)
        {
            var existing = context.Orders.Find(id);
            existing.customerId = (Guid)order.customerId;
            existing.businessId = (Guid)order.businessId;
            existing.status = (OrderStatus)order.status;
            existing.price = (double)order.price;
            existing.createdOn = (DateTime)order.createdOn;
            existing.completedOn = (DateTime)order.completedOn;
            existing.comments = order.comments;
            existing.discountId = (Guid)order.discountId;
            existing.deliveryAddress = order.deliveryAddress;
            List<Item> items = new List<Item>();
            foreach (Guid itemId in order.itemIds)
            {
                Item i = context.Items.Find(itemId);
                if (i != null)
                {
                    items.Add(i);
                }
            }
            existing.items = items;
            context.Orders.Update(existing);
            context.SaveChanges();
            return existing;
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
