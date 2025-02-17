﻿using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.OrderData
{
    public interface IOrderData
    {
        List<Order> GetOrders();
        Order GetOrder(Guid id);
        Order AddOrder(OrderDTO order);
        void DeleteOrder(Guid id);
        Order EditOrder(Guid id, OrderDTO order);
        Order PatchOrder(Guid id, OrderDTO order);
    }
}
