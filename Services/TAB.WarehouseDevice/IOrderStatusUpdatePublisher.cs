using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Foundation.Messaging;
using IQ.Foundation.Messaging.AzureServiceBus;
using TAB.Models.Order;

namespace TAB.WarehouseDevice
{
	public interface IOrderStatusUpdatePublisher
	{
		void Publish(OrderStatusUpdate orderStatusUpdate);
	}

	public class OrderStatusUpdatePublisher : IOrderStatusUpdatePublisher
	{
		private IEnqueueMessages _queuePublisher;

		public OrderStatusUpdatePublisher()
		{
			var bootstrapper = new DefaultAzureServiceBusBootstrapper(new OrderStatusUpdateConfiguration());
			_queuePublisher = bootstrapper.BuildQueueProducer();
		}

		public void Publish(OrderStatusUpdate orderStatusUpdate)
		{
			_queuePublisher.Enqueue("tab.order.commands", orderStatusUpdate);
		}
	}
}