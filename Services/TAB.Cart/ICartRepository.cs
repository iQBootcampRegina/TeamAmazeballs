using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using TAB.Models.Product;

namespace TAB.Cart
{
    public interface ICartRepository
    {
        Models.Cart.Cart Create();
        Models.Cart.Cart Get(int id);
        Models.Cart.Cart Update(Models.Cart.Cart cart);
        void Delete(int id);
    }

    class FakeCartRepository : ICartRepository
    {
        private IDictionary<int, Models.Cart.Cart> _carts; 
        private Fixture _fixture;

        public FakeCartRepository()
        {
            _carts = new Dictionary<int, Models.Cart.Cart>();
            _fixture = new Fixture();
        }
        public Models.Cart.Cart Create()
        {
            var cart = _fixture.Build<Models.Cart.Cart>().With(x => x.Items, new List<Product>()).Create();

            _carts.Add(cart.Id, cart);
            return cart;
        }

        public Models.Cart.Cart Get(int id)
        {
            return _carts.FirstOrDefault(x => x.Key == id).Value;
        }

        public Models.Cart.Cart Update(Models.Cart.Cart cart)
        {
            if (_carts.Any(x => x.Key == cart.Id))
                _carts[cart.Id] = cart;
            else
                _carts.Add(cart.Id, cart);

            return cart;
        }

        public void Delete(int id)
        {
            _carts.Remove(id);
        }
    }
}