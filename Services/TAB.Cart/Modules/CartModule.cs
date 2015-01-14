using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace TAB.Cart.Modules
{
	public class CartModule : NancyModule
	{
	    private ICartRepository _cartRepository;


	    public CartModule(ICartRepository cartRepository) : base("/Carts")
	    {
	        _cartRepository = cartRepository;
	        Post["/"] = x => CreateCart();
            Get["/{cartId}"] = x => GetCart(x.cartId);
            Delete["/{cartId}"] = x => DeleteCart(x.cartId);
	    }

	    private object DeleteCart(int cartId)
	    {
            _cartRepository.Delete(cartId);
	        return HttpStatusCode.NoContent;
	    }

	    private object GetCart(int cartId)
	    {
	        return _cartRepository.Get(cartId);
	    }

	    private object CreateCart()
	    {
	        return _cartRepository.Create();
	    }
	}
}