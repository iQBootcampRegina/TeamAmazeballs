using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.AzureServiceBus;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;
using IQ.Foundation.Messaging.HandlerResolution;
using IQ.Foundation.Messaging.MessageHandling;

namespace TAB.WarehouseDeviceBus
{
	public class OrderServiceBusBootstrapper : AzureServiceBusBootstrapper
	{
		private readonly IResolveMessageHandler _resolver;

		public OrderServiceBusBootstrapper(IProvideServiceBusConfiguration serviceBusConfigurationProvider)
			: base(serviceBusConfigurationProvider)
        {
            _resolver = new HandlerResolver();
        }

        protected override IResolveMessageHandler MessageHandlerResolver
        {
            get { return _resolver; }
        }

        class HandlerResolver : IResolveMessageHandler
        {
            private readonly IHandleMessages _handlerInstance;

            public HandlerResolver()
            {
                _handlerInstance = new OrderHandler();
            }

            public IHandleMessages Resolve(object message)
            {
                return _handlerInstance;
            }
        }
	}
}
