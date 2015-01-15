using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
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

			Get["/SubOrders"] = x => GetAllOrders(x.WarehouseId);
		}

		public object GetAllOrders(int warehouseId)
		{
			var warehouse = WarehouseService.GetWarehouseById(warehouseId);
			if (warehouse == null)
				return HttpStatusCode.BadRequest;

			return OrderRepository.GetAllOrders().SelectMany(o => o.SubOrders).Where(s => s.WarehouseId == warehouseId).ToArray();
		}
	}
}