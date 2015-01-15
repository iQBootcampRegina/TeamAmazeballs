using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using OrderBuilderApi.Model;

namespace OrderBuilderApi.ApiServices
{
    public class ItemApiService : IApiApplicationService<Item, int>
    {
        public ResourceCreationResult<Item, int> Create(Item resource, IRequestContext context)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetMany(IRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id, IRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Item Update(Item resource, IRequestContext context)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, IRequestContext context)
        {
            throw new NotImplementedException();
        }
    }
}
