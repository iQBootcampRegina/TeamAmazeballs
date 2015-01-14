﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using TAB.Cart.Models;

namespace TAB.Cart.Modules
{
	public class CartItemModule : NancyModule
	{
		public ICartRepository CartRepository { get; private set; }

		public CartItemModule(ICartRepository cartRepository)
			: base("/Carts/{CartId}")
		{
			CartRepository = cartRepository;

			Get["/Items"] = x => GetItemsByCartId(x.CartId);
			Get["/Items/{Id}"] = x => GetItemById(x.CartId, x.Id);
		}

		private object GetItemsByCartId(int cartId)
		{
			return "Heres your id " + cartId;
		}

		private object GetItemById(int cartId, int id)
		{
			return CartRepository.ToString();
		}
	}
}