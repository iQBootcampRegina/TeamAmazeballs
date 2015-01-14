using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace TAB.Cart.Modules
{
	public class CartItemModule : NancyModule
	{
		public CartItemModule()
			: base("/Carts/{CartId}")
		{
			Get["/Items"] = x => GetItemsByCartId(x.CartId);
			Get["/Items/{Id}"] = x => GetItemById(x.CartId, x.Id);
		}

		private object GetItemsByCartId(int cartId)
		{
			return "Heres your id " + cartId;
		}

		private object GetItemById(int cartId, int id)
		{
			return cartId + " | " + id;
		}
	}
}