﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAB.WarehouseDevice.Models
{
	public class Order
	{
		public int Id { get; set; }
		public SubOrder[] SubOrders { get; set; }
		public bool Shipped { get; set; }
	}
}