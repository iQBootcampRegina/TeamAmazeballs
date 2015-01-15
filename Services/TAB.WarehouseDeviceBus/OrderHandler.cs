using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.MessageHandling;
using TAB.Models.Order;

namespace TAB.WarehouseDeviceBus
{
	public class OrderHandler : IQ.Foundation.Messaging.MessageHandling.BaseMessageHandler<Order>
	{
		public override void Handle(Order message)
		{
			HttpClient client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:57483/Orders");
		}
	}
}
