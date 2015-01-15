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
	public class SubOrderModule : NancyModule
	{
		public IWarehouseService WarehouseService { get; private set; }
		public IOrderRepository OrderRepository { get; private set; }
		
		public SubOrderModule(IWarehouseService warehouseService, IOrderRepository orderRepository)
			: base("Warehouses/{WarehouseId}")
		{
			WarehouseService = warehouseService;

			Get["/SubOrders"] = x => GetAllSubOrders(x.WarehouseId);
			Get["/SubOrders/{Id}"] = x => GetSubOrderById(x.WarehouseId, x.Id);
			Put["/SubOrders/{Id}"] = x => UpdateSubOrder(x.WarehouseId, x.Id);
		}

		private object GetAllSubOrders(int warehouseId)
		{
			var warehouse = WarehouseService.GetWarehouseById(warehouseId);
			if (warehouse == null)
				return HttpStatusCode.BadRequest;

			return OrderRepository.GetAllOrders().SelectMany(o => o.SubOrders).Where(s => s.WarehouseId == warehouseId).ToArray();
		}

		private object GetSubOrderById(int warehouseId, int subOrderId)
		{
			var warehouse = WarehouseService.GetWarehouseById(warehouseId);
			if (warehouse == null)
				return HttpStatusCode.BadRequest;

			var subOrder = OrderRepository.GetSubOrderById(subOrderId);
			if (subOrder == null)
				return HttpStatusCode.BadRequest;

			return subOrder;
		}

		private object UpdateSubOrder(int warehouseId, int subOrderId)
		{
			var newSubOrder = this.Bind<SubOrder>();

			var warehouse = WarehouseService.GetWarehouseById(warehouseId);
			if (warehouse == null || newSubOrder.WarehouseId != warehouseId)
				return HttpStatusCode.BadRequest;

			var subOrder = OrderRepository.GetSubOrderById(subOrderId);
			if (subOrder == null || newSubOrder.OrderId != subOrderId)
				return HttpStatusCode.BadRequest;

			if (subOrder.Shipped || (!newSubOrder.Shipped && newSubOrder.Claimed && subOrder.Claimed))
				return HttpStatusCode.BadRequest;

			var order = OrderRepository.GetOrderById(subOrder.OrderId);
			if (order == null)
				return HttpStatusCode.InternalServerError;

			var existingSubOrder = order.SubOrders.First(s => s.Id == subOrderId);
			existingSubOrder.Claimed = newSubOrder.Claimed;
			existingSubOrder.Shipped = newSubOrder.Shipped;

			OrderRepository.UpdateOrder(order);

			return HttpStatusCode.NoContent;
		}
	}
}