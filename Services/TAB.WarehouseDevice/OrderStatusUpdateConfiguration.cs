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
		    get
		    {
		        return
		            "Endpoint=sb://iqbootcamp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DYR29cbRrvBi1ADCztJQ99vlTOyPDVFAtLOgO8yWgN8=";
		    }
		    //"Endpoint=sb://iq-azgddlocal.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=+kXqZEalbQwKlsUq9B9NzA2TYX2JUorpOXSOAZIsGAc="; }
		}

		public override string ServiceIdentifier
		{
			get { return "tab.order.commands.warehouse"; }
		}
	}
}