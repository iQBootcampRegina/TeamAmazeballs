using System.Collections.Generic;

namespace TAB.Cart.Models
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<Product>();
        }

        public int Id { get; set; }
        public IList<Product> Items { get; set; }
    }
}