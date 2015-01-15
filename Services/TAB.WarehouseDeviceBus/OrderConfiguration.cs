﻿using System;
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
			get { return "Endpoint=sb://iq-azgddlocal.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=+kXqZEalbQwKlsUq9B9NzA2TYX2JUorpOXSOAZIsGAc="; }
		}

		public override string ServiceIdentifier
		{
			get { return "TAB.Order.Notifications"; }
		}
	}
}