using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.AzureServiceBus;

namespace TAB.WarehouseDeviceBus
{
	class Program
	{
		static void Main(string[] args)
		{
			new OrderServiceBusBootstrapper(new OrderConfiguration());
		}
	}
}
