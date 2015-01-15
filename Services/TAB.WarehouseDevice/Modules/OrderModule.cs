using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using TAB.WarehouseDevice.Services;

namespace TAB.WarehouseDevice.Modules
{
	public class OrderModule : NancyModule
	{
		public IWarehouseService WarehouseService { get; private set; }
		
		public OrderModule(IWarehouseService warehouseService)
			: base("Warehouses/{WarehouseId}")
		{
			WarehouseService = warehouseService;
		}
	}
}