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
		void AddOrder(Order order);
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
			throw new NotImplementedException();
		}
	}
}