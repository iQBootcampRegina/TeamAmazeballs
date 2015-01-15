using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using TAB.Models.Order;
using TAB.WarehouseDevice.Services;

namespace TAB.WarehouseDevice.Modules
{
	public class OrdersModule : NancyModule
	{
		public IInventoryService InventoryService { get; private set; }

		public OrdersModule(IInventoryService inventoryService)
			: base("Orders")
		{
			InventoryService = inventoryService;

			Post["/"] = x => AddOrder();
		}

		private object AddOrder()
		{
			var order = this.Bind<Order>();
			if (order == null || order.Id < 1)
				return HttpStatusCode.BadRequest;



			return HttpStatusCode.Created;
		}
	}
}