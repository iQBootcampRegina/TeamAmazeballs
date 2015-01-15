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

        public Task<Order> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<Order, int>> CreateAsync(Order resource, IRequestContext context,
                                                                      CancellationToken cancellation)
        {
            return Task.FromResult(new ResourceCreationResult<Order, int>(new Order{Status = OrderStatus.NeedsShippingDetails}));
        }

        public Task<Order> UpdateAsync(Order resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Order, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
