using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging;
using IQ.Foundation.Messaging.AzureServiceBus;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;
using IQ.Foundation.Messaging.MessageHandling;
using TAB.Models.Order;

namespace TAB.Order.Webjob
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new DefaultAzureServiceBusBootstrapper(new OrderQueueConfiguration());

            var orderRepo = new OrderRepository();
            var notificationPublisher = bootstrapper.BuildMessagePublisher();
            var orderHandler = new OrderHandler(orderRepo, notificationPublisher);
            var orderStatusUpdateHandler = new OrderStatusUpdateHandler(orderRepo);

            bootstrapper.MessageHandlerRegisterer.Register<Models.Order.Order>(orderHandler);
            bootstrapper.MessageHandlerRegisterer.Register<Models.Order.OrderStatusUpdate>(orderStatusUpdateHandler);
            bootstrapper.Subscribe();


            Console.WriteLine("Waiting for orders...");
            Console.ReadLine();
        }
    }

    public class OrderStatusUpdateHandler : BaseMessageHandler<Models.Order.OrderStatusUpdate>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderStatusUpdateHandler(IOrderRepository orderRepository)
        {
            if (orderRepository == null) throw new ArgumentNullException("orderRepository");
            _orderRepository = orderRepository;
        }

        public override void Handle(OrderStatusUpdate message)
        {
            _orderRepository.UpdateToShippedStatus(message);
        }
    }

    public class OrderHandler : BaseMessageHandler<Models.Order.Order>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IPublishMessages _publisher;

        public OrderHandler(IOrderRepository orderRepo, IPublishMessages publisher)
        {
            if (orderRepo == null) throw new ArgumentNullException("orderRepo");
            _orderRepo = orderRepo;
            _publisher = publisher;
        }

        public override void Handle(Models.Order.Order message)
        {
            _orderRepo.CreateOrder(message);

            _publisher.Publish(message);
        }
    }

    class OrderNotificationsConfiguration : ConventionServiceBusConfiguration
    {
        public override string ConnectionString
        {
            get
            {
                return
                    "Endpoint=sb://iqbootcamp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DYR29cbRrvBi1ADCztJQ99vlTOyPDVFAtLOgO8yWgN8=";
//                    "Endpoint=sb://iq-azgddlocal.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=+kXqZEalbQwKlsUq9B9NzA2TYX2JUorpOXSOAZIsGAc=";
            }
        }

        public override string ServiceIdentifier
        {
            get { return "tab.order.notifications"; }
        }

        protected override bool PublishesMessages
        {
            get { return true; }
        }
    }

    class OrderQueueConfiguration : ConventionServiceBusConfiguration
    {
        public override string ConnectionString
        {
            get
            {
                return
                    "Endpoint=sb://iqbootcamp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DYR29cbRrvBi1ADCztJQ99vlTOyPDVFAtLOgO8yWgN8=";
//                    "Endpoint=sb://iq-azgddlocal.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=+kXqZEalbQwKlsUq9B9NzA2TYX2JUorpOXSOAZIsGAc=";
            }
        }

        public override string ServiceIdentifier
        {
            get { return "tab.order.commands"; }
        }

        protected override bool ConsumesQueue
        {
            get { return true; }
        }
    }
}
