using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using OrderBuilderApi.Model;

namespace OrderBuilderApi.ApiServices
{
    public class ItemApiService : IApiService<Item, int>
    {
        public Task<Item> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<Item, int>> CreateAsync(Item resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateAsync(Item resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Item, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
