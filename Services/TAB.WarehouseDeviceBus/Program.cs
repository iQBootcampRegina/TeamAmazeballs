using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.AzureServiceBus;
using TAB.Models.Order;

namespace TAB.WarehouseDeviceBus
{
	class Program
	{
		static void Main(string[] args)
		{
			var bootstrapper = new DefaultAzureServiceBusBootstrapper(new OrderConfiguration());
			bootstrapper.MessageHandlerRegisterer.Register(new OrderHandler());
			bootstrapper.Subscribe();
		}
	}
}
