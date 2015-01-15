using System.Collections.Generic;

namespace TAB.Models.Cart
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<Product.Product>();
        }

        public int Id { get; set; }
        public IList<Product.Product> Items { get; set; }
    }
}