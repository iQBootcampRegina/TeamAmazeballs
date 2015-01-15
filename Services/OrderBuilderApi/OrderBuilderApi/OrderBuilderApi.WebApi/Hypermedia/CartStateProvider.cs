using System;
using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using OrderBuilderApi.Model;

namespace OrderBuilderApi.WebApi.Hypermedia
{
    public class OrderStateProvider : ResourceStateProviderBase<Cart, CartStatus>
    {
        public override CartStatus GetFor(Cart resource)
        {
            return resource.Status;
        }

        protected override IDictionary<CartStatus, IEnumerable<CartStatus>> GetTransitions()
        {
            return new Dictionary<CartStatus, IEnumerable<CartStatus>>
			       {
			           {
			               CartStatus.Created, new [] 
                           {
                                CartStatus.Empty,
			               }
			           },
				       {
					       CartStatus.Empty, new[]
                            {
                                CartStatus.HasItems,
                            }
				       },
                       //{
                       //    CartStatus.HasItems, new []
                       //        {
                       //            CartStatus.Empty, 
                       //        }
                       //}
			       };
        }

        public override IEnumerable<CartStatus> All
        {
            get { return EnumEx.GetValuesFor<CartStatus>(); }
        }

        public override bool IsInitial(CartStatus state)
        {
            var i = base.IsInitial(state);
            return i;
        }
    }
}