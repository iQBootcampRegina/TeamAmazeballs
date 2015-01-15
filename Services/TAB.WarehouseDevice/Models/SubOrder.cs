using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAB.WarehouseDevice.Models
{
	public class SubOrder
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int WarehouseId { get; set; }
		public Product[] Items { get; set; }
		public bool Shipped { get; set; }
	}
}