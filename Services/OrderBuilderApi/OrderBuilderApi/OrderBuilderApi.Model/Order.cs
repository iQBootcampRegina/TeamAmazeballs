using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace OrderBuilderApi.Model
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Order : IStatefulResource<OrderStatus>, IIdentifiable<int>
    {
        public Order()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Unique Identifier for the cart
        /// </summary>
        public int Id { get; set; }
        public IList<Item> Items { get; set; }
        public ShippingInfo ShippingInfo { get; set; }
        public ShippingOption ShippingOption { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public OrderStatus Status { get; set; }
        
    }
}
