using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;

namespace TAB.WarehouseDeviceBus
{
	public class OrderConfiguration : ConventionServiceBusConfiguration
	{
		protected override IEnumerable<string> SubscriptionTopics
		{
			get { yield return ServiceIdentifier; }
		}

		public override string ConnectionString
		{
            get { return "Endpoint=sb://iqbootcamp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DYR29cbRrvBi1ADCztJQ99vlTOyPDVFAtLOgO8yWgN8="; }
		}

		public override string ServiceIdentifier
		{
			get { return "tab.order.notifications"; }
		}
	}
}