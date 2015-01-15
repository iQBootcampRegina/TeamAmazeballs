using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBuilderApi.Model
{
    public enum OrderStatus
    {
        Created,
        NeedsShippingDetails,
        WaitingForConfirmation,
        WaitingForPayment,
        Completed,
        Shipped
    }
}
