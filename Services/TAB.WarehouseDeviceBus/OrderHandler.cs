using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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
			Console.WriteLine("Order " + message.Id + " received!");
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:57483/Orders");
			request.Content = new ObjectContent(typeof(Order), message, new JsonMediaTypeFormatter(), "application/json");
			var task = client.SendAsync(request);

			//var task = new HttpClient().PostAsJsonAsync("http://localhost:57483/Orders", message);
			if (!task.Wait(30000) || task.Status != TaskStatus.Created)
				throw new Exception();

			Console.WriteLine("Sent to Warehouse Device Service!");
		}
	}
}
