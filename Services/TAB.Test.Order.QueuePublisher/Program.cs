using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.AzureServiceBus;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;
using Ploeh.AutoFixture;

namespace TAB.Test.Order.QueuePublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new DefaultAzureServiceBusBootstrapper(new SampleQueueProducerConfiguration());

            var messagePublisher = bootstrapper.BuildQueueProducer();

            var order = CreateOrder();

            messagePublisher.Enqueue("tab.order.commands", order);
        }

        private static Models.Order.Order CreateOrder()
        {
            var fixture = new Fixture();

            return fixture.Create<Models.Order.Order>();
        }
    }

    public class SampleQueueProducerConfiguration : ConventionServiceBusConfiguration
    {
        public override string ConnectionString
        {
            get { return "Endpoint=sb://iqbootcamp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DYR29cbRrvBi1ADCztJQ99vlTOyPDVFAtLOgO8yWgN8"; }
        }

        public override string ServiceIdentifier
        {
            get { return "tab.order.commands.testpublisher"; }
        }
    }

}
