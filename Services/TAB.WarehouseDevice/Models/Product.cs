using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAB.WarehouseDevice.Models
{
	public class Product
	{
		public int Id { get; set; }
		public int SKU { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
	}
}