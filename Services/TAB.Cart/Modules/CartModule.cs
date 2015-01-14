using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace TAB.Cart.Modules
{
	public class CartModule : NancyModule
	{
	    public CartModule() : base("/Carts")
	    {
            Post["/"] = x => CreateCart();
            Get["/{cartId}"] = x => GetCart(x.cartId);
            Delete["/{cartId}"] = x => DeleteCart(x.cartId);
	    }

	    private object DeleteCart(int cartId)
	    {
	        throw new NotImplementedException();
	    }

	    private object GetCart(int cartId)
	    {
	        return "Got cart #" + cartId.ToString();
	    }

	    private object CreateCart()
	    {
	        throw new NotImplementedException();
	    }
	}
}