using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace TAB.Cart
{
	public class NancyBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
		{
			container.Register<ICartRepository>(new FakeCartRepository());

			base.ConfigureApplicationContainer(container);
		}
	}
}