using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;

namespace TAB.WarehouseDevice
{
	public class OrderStatusUpdateConfiguration : ConventionServiceBusConfiguration
	{
		public override string ConnectionString
		{
			get { return "Endpoint=sb://iq-test.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=SsMHVTRxt6st4C7nZLLMYk9wWIn7n4rvudXDWBHQdXo="; }
		}

		public override string ServiceIdentifier
		{
			get { return "IQ.SampleQueueProducer"; }
		}
	}
}