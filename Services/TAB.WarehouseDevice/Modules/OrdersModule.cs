using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using TAB.WarehouseDevice.Models;
using TAB.WarehouseDevice.Services;

namespace TAB.WarehouseDevice.Modules
{
	public class OrdersModule : NancyModule
	{
		public IInventoryService InventoryService { get; private set; }
		public IWarehouseService WarehouseService { get; private set; }
		public IOrderRepository OrderRepository { get; private set; }

		public OrdersModule(IInventoryService inventoryService, IWarehouseService warehouseService, IOrderRepository orderRepository)
			: base("Orders")
		{
			InventoryService = inventoryService;
			WarehouseService = warehouseService;
			OrderRepository = orderRepository;

			Post["/"] = x => AddOrder();
		}

		private object AddOrder()
		{
			var order = this.Bind<TAB.Models.Order.Order>();
			if (order == null || order.Id < 1)
				return HttpStatusCode.BadRequest;

			Dictionary<int, int> perWarehouseCount = WarehouseService.GetAllWarehouses().ToDictionary(w => w.Id, w => 0);
			foreach (var subOrder in OrderRepository.GetAllOrders().SelectMany(o => o.SubOrders))
				++perWarehouseCount[subOrder.WarehouseId];

			var warehouseIds = perWarehouseCount.OrderBy(kvp => kvp.Value).Select(kvp => kvp.Key).ToArray();

			var newOrder = new Order()
			{
				Id = order.Id,
				Shipped = false,
				SubOrders = new SubOrder[0]
			};

			int warehouseIndex = 0;
			while (order.Products.Count > 0)
			{
				if (warehouseIndex >= warehouseIds.Length)
				{
					// Out of stock items
					break;
				}
				int warehouseId = warehouseIds[warehouseIndex];
				List<TAB.Models.Product.Product> products = new List<TAB.Models.Product.Product>();
				int currentProduct = 0;
				int quantity = 0;
				while (order.Products.Count > 0 && currentProduct < order.Products.Count)
				{
					quantity = InventoryService.GetStockById(order.Products[currentProduct].Id, warehouseId);
					var product = order.Products[currentProduct];
					if (quantity >= product.Quantity)
					{
						products.Add(Copy(product));
						order.Products.RemoveAt(currentProduct);
					}
					else
					{
						product.Quantity -= quantity;
						if (quantity > 0)
						{
							var p = Copy(product);
							p.Quantity = quantity;
							products.Add(p);
						}
						++currentProduct;
					}
				}
				if (products.Count > 0)
				{
					var subOrder = new SubOrder()
					{
						Id = OrderRepository.GetNextSubOrderId(),
						Claimed = false,
						Shipped = false,
						OrderId = order.Id,
						WarehouseId = warehouseId,
						Items = products.Select(p =>
							{
								return new Product()
								{
									Id = p.Id,
									Name = p.Name,
									Quantity = p.Quantity,
									Sku = p.Sku
								};
							}).ToArray()
					};
					newOrder.SubOrders = newOrder.SubOrders.Concat(new[] { subOrder }).ToArray();
				}
				++warehouseIndex;
			}

			OrderRepository.AddOrder(newOrder);

			return HttpStatusCode.Created;
		}

		private TAB.Models.Product.Product Copy(TAB.Models.Product.Product product)
		{
			return new TAB.Models.Product.Product()
			{
				Id = product.Id,
				Description = product.Description,
				Name = product.Name,
				Price = product.Price,
				Quantity = product.Quantity,
				Sku = product.Sku
			};
		}
	}
}