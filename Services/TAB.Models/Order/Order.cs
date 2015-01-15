using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAB.Models.Order
{
    public class Order
    {
		public int Id { get; set; }
        public IList<Product.Product> Products { get; set; }
        public Shipping.ShippingInfo ShippingInfo { get; set; }
        public Shipping.ShippingOption ShippingOption { get; set;  }
        public Payment.PaymentInfo PaymentInfo { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
