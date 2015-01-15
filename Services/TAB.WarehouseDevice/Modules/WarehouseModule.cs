using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using TAB.WarehouseDevice.Services;

namespace TAB.WarehouseDevice.Modules
{
	public class WarehouseModule : NancyModule
	{
		public IWarehouseService WarehouseService { get; private set; }

		public WarehouseModule(IWarehouseService warehouseService)
			: base("Warehouses")
		{
			WarehouseService = warehouseService;

			Get["/"] = x => GetAllWarehouses();
			Get["/{Id}"] = x => GetWarehouseById(x.Id);
		}

		private object GetAllWarehouses()
		{
			return WarehouseService.GetAllWarehouses();
		}

		private object GetWarehouseById(int id)
		{
			var warehouse = WarehouseService.GetWarehouseById(id);
			if (warehouse == null)
				return HttpStatusCode.BadRequest;
			return warehouse;
		}
	}
}