using System;
using System.Collections.Generic;
using System.Linq;
using TAB.Models.Order;

namespace TAB.Order.Webjob
{
   public interface IOrderRepository
    {
        void CreateOrder(Models.Order.Order order);
        Models.Order.Order UpdateToShippedStatus(Models.Order.OrderStatusUpdate status);
    }

    class OrderRepository : IOrderRepository
    {
        private IList<Models.Order.Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Models.Order.Order>();
        }

        public void CreateOrder(Models.Order.Order order)
        {
            _orders.Add(order);
        }

        public Models.Order.Order UpdateToShippedStatus(OrderStatusUpdate status)
        {
            if(!_orders.Any(x => x.Id == status.Id))
                throw new ArgumentException("Order not found.");

            _orders.First(x => x.Id == status.Id).OrderStatus = OrderStatus.Shipped;
        }
    }
}