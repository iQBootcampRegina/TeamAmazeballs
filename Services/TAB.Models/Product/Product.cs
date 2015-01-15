namespace TAB.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
    }
}