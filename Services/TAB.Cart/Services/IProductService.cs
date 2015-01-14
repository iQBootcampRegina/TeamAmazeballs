using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using TAB.Cart.Models;

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
            return _products.FirstOrDefault(x => x.Id == id);
        }


        private void PopulateProducts()
        {
            var fixture = new Fixture();

            fixture.AddManyTo(_products, 100);
        }
    }
}