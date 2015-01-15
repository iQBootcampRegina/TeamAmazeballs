using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using OrderBuilderApi.ApiServices.Security;
using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi;

namespace OrderBuilderApi.ApiServices
{
    public class OrderApiService : IApiService<Order, int>
    {
        private static List<Order> _orders;
        public List<Order> Orders
        {
            get { return (_orders) ?? (_orders = new List<Order>()); }
        } 

        public Task<Order> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            return Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
        }

        public Task<IEnumerable<Order>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<ResourceCreationResult<Order, int>> CreateAsync(Order resource, IRequestContext context,
                                                                      CancellationToken cancellation)
        {
            resource.Status = OrderStatus.NeedsShippingDetails;
            resource.Id = (Orders.Any())?_orders.Max(o => o.Id + 1):1;
            Orders.Add(resource);

            return Task.FromResult(new ResourceCreationResult<Order, int>(resource));
        }

        public Task<Order> UpdateAsync(Order resource, IRequestContext context, CancellationToken cancellation)
        {
            var order = Orders.FirstOrDefault(o => o.Id == resource.Id);
            if (order == null) return null;

            if (order.Status == OrderStatus.NeedsShippingDetails)
            {
                order.ShippingInfo = resource.ShippingInfo;
                order.ShippingOption = resource.ShippingOption;
                order.Status = OrderStatus.WaitingForPayment;
                return Task.FromResult(order);
            }
            if (order.Status == OrderStatus.WaitingForPayment)
            {
                order.PaymentInfo = resource.PaymentInfo;
                order.Status = OrderStatus.WaitingForConfirmation;
                return Task.FromResult(order);
            }
            if (order.Status == OrderStatus.WaitingForConfirmation)
            {
                order.Status = OrderStatus.Completed;
                //Publish topic
                return Task.FromResult(order);
            }
            return Task.FromResult(order);
        }

        public Task DeleteAsync(ResourceOrIdentifier<Order, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
