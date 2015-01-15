using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using JetBrains.Annotations;
using OrderBuilderApi.ApiServices.Security;
using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi;

namespace OrderBuilderApi.ApiServices
{
    public class ApiService : IApiService<Cart, int>
    {
        private readonly ICartService _cartService;

        public ApiService(ICartService cartService)
        {
            if (cartService == null) throw new ArgumentNullException("cartService");
            _cartService = cartService;
        }

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
            var cart = _cartService.CreateCart();
            cart.Status = CartStatus.Empty;

            return Task.FromResult(new ResourceCreationResult<Cart, int>(cart));
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
