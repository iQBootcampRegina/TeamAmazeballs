using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace OrderBuilderApi.Model
{
	public class ShippingInfo
	{
		public Address Destination { get; set; }
		public string CourierService { get; set; }
	}
}
