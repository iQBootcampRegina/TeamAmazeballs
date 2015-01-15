using System;
using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using OrderBuilderApi.Model;

namespace OrderBuilderApi.WebApi.Hypermedia
{
    public class OrderStateProvider : ResourceStateProviderBase<Order, OrderStatus>
    {
        public override OrderStatus GetFor(Order resource)
        {
            return resource.Status;
        }

        protected override IDictionary<OrderStatus, IEnumerable<OrderStatus>> GetTransitions()
        {
            return new Dictionary<OrderStatus, IEnumerable<OrderStatus>>
			       {
			           {
			               OrderStatus.Created, new [] 
                           {
                                OrderStatus.NeedsShippingDetails
			               }
			           },
				       {
					       OrderStatus.NeedsShippingDetails, new[]
                            {
                                OrderStatus.WaitingForPayment
                            }
				       },
				       {
					       OrderStatus.WaitingForPayment, new[]
                            {
                                OrderStatus.WaitingForConfirmation
                            }
				       },
				       {
					       OrderStatus.WaitingForConfirmation, new[]
                            {
                                OrderStatus.Completed
                            }
				       },
				       {
					       OrderStatus.Completed, new[]
                            {
                                OrderStatus.Shipped
                            }
				       }
			       };
        }

        public override IEnumerable<OrderStatus> All
        {
            get { return EnumEx.GetValuesFor<OrderStatus>(); }
        }

        public override bool IsInitial(OrderStatus state)
        {
            var i = base.IsInitial(state);
            return i;
        }
    }
}