using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using TAB.Models.Product;

namespace TAB.Cart.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
    }

    class FakeProductService : IProductService
    {
        private IList<Product> _products;

        public FakeProductService()
        {
            _products = new List<Product>();
            PopulateProducts();
        }

        public Product GetProductById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
			if (product == null)
				return null;
			return new Product()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Sku = product.Sku, 
				Quantity = 0
			};
        }


        private void PopulateProducts()
        {
            var fixture = new Fixture();
            fixture.AddManyTo(_products, 100);
			for (int i = 0; i < _products.Count; ++i)
				_products[i].Id = i + 1;
        }
    }
}