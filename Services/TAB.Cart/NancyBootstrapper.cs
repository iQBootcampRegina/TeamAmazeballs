using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using TAB.Cart.Services;

namespace TAB.Cart
{
	public class NancyBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
		{
			container.Register<ICartRepository>(new FakeCartRepository());
			container.Register<IProductService>(new FakeProductService());

			base.ConfigureApplicationContainer(container);
		}
	}
}