using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAB.WarehouseDevice.Models;

namespace TAB.WarehouseDevice
{
	public interface IOrderRepository
	{
		IEnumerable<Order> GetAllOrders();
		Order GetOrderById(int id);
		SubOrder GetSubOrderById(int subOrderId);
		void AddOrder(Order order);
		void UpdateOrder(Order order);
	}

	public class FakeOrderRepository : IOrderRepository
	{
		private IList<Order> _orders;

		public FakeOrderRepository()
		{
			_orders = new List<Order>();
		}

		public IEnumerable<Order> GetAllOrders()
		{
			return _orders.Select(o => GetOrderById(o.Id)).ToArray();
		}

		public Order GetOrderById(int id)
		{
			var order = _orders.FirstOrDefault(x => x.Id == id);
			if (order == null)
				return null;
			return new Order()
			{
				Id = order.Id,
				Shipped = order.Shipped,
				SubOrders = order.SubOrders.Select(o =>
					{
						return new SubOrder()
						{
							Id = o.Id,
							OrderId = o.OrderId,
							Claimed = o.Claimed,
							Shipped = o.Shipped,
							WarehouseId = o.WarehouseId,
							Items = o.Items.Select(i =>
								{
									return new Product()
									{
										Id = i.Id, 
										Name = i.Name,
										Quantity = i.Quantity,
										SKU = i.SKU
									};
								}).ToArray()
						};
					}).ToArray()
			};
		}

		public void AddOrder(Order order)
		{
			if (_orders.Any(o => o.Id == order.Id))
				throw new Exception("Order already added.");
			_orders.Add(order);
		}


		public void UpdateOrder(Order order)
		{
			for (int i = 0; i < _orders.Count; ++i)
			{
				if (_orders[i].Id == order.Id)
				{
					_orders[i] = order;
					return;
				}
			}
			throw new Exception("Order not found.");
		}


		public SubOrder GetSubOrderById(int subOrderId)
		{
			return _orders.SelectMany(o => o.SubOrders).FirstOrDefault(s => s.Id == subOrderId);
		}
	}
}