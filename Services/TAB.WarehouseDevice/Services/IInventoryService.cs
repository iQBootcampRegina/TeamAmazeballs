using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAB.WarehouseDevice.Services
{
	public interface IInventoryService
	{
		int GetStockById(int productId, int warehouseId);
	}

	public class FakeInventoryService : IInventoryService
	{
		public int GetStockById(int productId, int warehouseId)
		{
			return 5;
		}
	}
}