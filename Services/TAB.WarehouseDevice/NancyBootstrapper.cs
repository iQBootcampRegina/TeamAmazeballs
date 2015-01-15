﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.TinyIoc;
using TAB.WarehouseDevice.Services;

namespace TAB.WarehouseDevice
{
	public class NancyBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			container.Register<IWarehouseService>(new FakeWarehouseService());
			container.Register<IInventoryService>(new FakeInventoryService());
			container.Register<IOrderRepository>(new FakeOrderRepository());
			base.ConfigureApplicationContainer(container);
		}
	}
}