using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Models.Global;

namespace TAB.Models.Shipping
{
	public class Shipping
	{
		public Address Destination { get; set; }
		public string CourierService { get; set; }
	}
}
