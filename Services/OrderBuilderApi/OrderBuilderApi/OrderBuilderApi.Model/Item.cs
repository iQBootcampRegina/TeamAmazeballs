using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace OrderBuilderApi.Model
{
    public class Item : IStatelessResource, IIdentifiable<int>
    {
        public int Id { get; private set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
    }
}
