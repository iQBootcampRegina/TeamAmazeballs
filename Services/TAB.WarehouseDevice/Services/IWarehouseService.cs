using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ploeh.AutoFixture;
using TAB.Models.Warehouse;

namespace TAB.WarehouseDevice.Services
{
	public interface IWarehouseService
	{
		IEnumerable<Warehouse> GetAllWarehouses();
		Warehouse GetWarehouseById(int id);
	}

	public class FakeWarehouseService : IWarehouseService
	{
		private IList<Warehouse> _warehouses;

		public FakeWarehouseService()
		{
			_warehouses = new List<Warehouse>();
			PopulateWarehouses();
		}

		public IEnumerable<Warehouse> GetAllWarehouses()
		{
			return _warehouses.Select(w => GetWarehouseById(w.Id)).ToArray();
		}

		public Warehouse GetWarehouseById(int id)
		{
			var warehouse = _warehouses.FirstOrDefault(x => x.Id == id);
			if (warehouse == null)
				return null;
			return new Warehouse()
			{
				Id = warehouse.Id,
				Name = warehouse.Name,
				Address = new TAB.Models.Global.Address()
				{
					Address1 = warehouse.Address.Address1,
					Address2 = warehouse.Address.Address2,
					City = warehouse.Address.City,
					PhoneNumber = warehouse.Address.PhoneNumber,
					PostalCode = warehouse.Address.PostalCode,
					Province = warehouse.Address.Province
				}
			};
		}

        private void PopulateWarehouses()
        {
            var fixture = new Fixture();
            fixture.AddManyTo(_warehouses, 3);
			for (int i = 0; i < _warehouses.Count; ++i)
				_warehouses[i].Id = i + 1;
        }
	}
}