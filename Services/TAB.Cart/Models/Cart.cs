using System.Collections.Generic;

namespace TAB.Cart.Models
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public IList<Item> Items { get; set; }
    }
}