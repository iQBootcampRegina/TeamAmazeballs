using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;

namespace TAB.Cart
{
    public interface ICartRepository
    {
        Models.Cart Create();
        Models.Cart Get(int id);
        Models.Cart Update(Models.Cart cart);
        void Delete(int id);
    }

    class FakeCartRepository : ICartRepository
    {
        private IDictionary<int, Models.Cart> _carts; 
        private Fixture _fixture;

        public FakeCartRepository()
        {
            _carts = new Dictionary<int, Models.Cart>();
            _fixture = new Fixture();
        }
        public Models.Cart Create()
        {
            var cart = _fixture.Create<Models.Cart>();

            _carts.Add(cart.Id, cart);
            return cart;
        }

        public Models.Cart Get(int id)
        {
            return _carts.FirstOrDefault(x => x.Key == id).Value;
        }

        public Models.Cart Update(Models.Cart cart)
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