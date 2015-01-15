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
    public class ApiService : IApiService<Cart, int>
    {

        public Task<Cart> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<Cart, int>> CreateAsync(Cart resource, IRequestContext context,
                                                                      CancellationToken cancellation)
        {
            return Task.FromResult(new ResourceCreationResult<Cart, int>(new Cart{Status = CartStatus.Empty}));
        }

        public Task<Cart> UpdateAsync(Cart resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Cart, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
