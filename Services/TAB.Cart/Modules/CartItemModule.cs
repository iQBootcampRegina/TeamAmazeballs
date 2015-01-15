using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using TAB.Cart.Services;
using TAB.Models.Product;

namespace TAB.Cart.Modules
{
	public class CartItemModule : NancyModule
	{
		public ICartRepository CartRepository { get; private set; }
		public IProductService ProductService { get; private set; }

		public CartItemModule(ICartRepository cartRepository, IProductService productService)
			: base("/Carts/{CartId}")
		{
			CartRepository = cartRepository;
			ProductService = productService;

			Get["/Items"] = x => GetItemsByCartId(x.CartId);
			Post["/Items"] = x => CreateItemInCart(x.CartId);
			Get["/Items/{Id}"] = x => GetItemById(x.CartId, x.Id);
			Put["/Items/{Id}"] = x => UpdateItemById(x.CartId, x.Id);
			Delete["/Items/{Id}"] = x => DeleteItemById(x.CartId, x.Id);
		}

		private object GetItemsByCartId(int cartId)
		{
			var cart = CartRepository.Get(cartId);
			if (cart == null)
				return HttpStatusCode.BadRequest;

			return cart.Items;
		}

		private object CreateItemInCart(int cartId)
		{
			var cart = CartRepository.Get(cartId);
			if (cart == null)
				return HttpStatusCode.BadRequest;
			
			var product = this.Bind<Product>();
			if (cart.Items.Any(i => i.Id == product.Id))
				return HttpStatusCode.BadRequest;
			var newProduct = ProductService.GetProductById(product.Id);
			if (newProduct == null)
				return HttpStatusCode.BadRequest;

			newProduct.Quantity = product.Quantity;
			cart.Items.Add(newProduct);

			return Negotiate.WithModel(newProduct).WithStatusCode(HttpStatusCode.Created);
		}

		private object GetItemById(int cartId, int id)
		{
			var cart = CartRepository.Get(cartId);
			if (cart == null)
				return HttpStatusCode.BadRequest;

			var product = cart.Items.FirstOrDefault(i => i.Id == id);
			if (product == null)
				return HttpStatusCode.NotFound;

			return product;
		}

		private object UpdateItemById(int cartId, int id)
		{
			var cart = CartRepository.Get(cartId);
			if (cart == null)
				return HttpStatusCode.BadRequest;

			var product = this.Bind<Product>();
			var existing = cart.Items.FirstOrDefault(i => i.Id == id);
			if (product == null || existing == null || product.Id != id)
				return HttpStatusCode.BadRequest;

			existing.Quantity = product.Quantity;

			return existing;
		}

		private object DeleteItemById(int cartId, int id)
		{
			var cart = CartRepository.Get(cartId);
			if (cart == null)
				return HttpStatusCode.BadRequest;

			var product = cart.Items.FirstOrDefault(i => i.Id == id);
			if (product == null)
				return HttpStatusCode.BadRequest;

			cart.Items.Remove(product);

			return HttpStatusCode.NoContent;
		}
	}
}