using System.Collections;
using System.Collections.Generic;
using SAMStock.Supplier.GetSuppliers;
using System.Linq;

namespace SAMStock.Web.Models.Supplier
{
	public class SuppliersViewModel
	{
		public SuppliersViewModel(GetSuppliersResponse getLeveranciersResponse)
		{
			Suppliers = getLeveranciersResponse.Suppliers
				.Select(x => new AdminViewModelSupplier { Address = x.Address, Name = x.Name, Website = x.Website }).ToList();
		}

		public List<AdminViewModelSupplier> Suppliers { get; set; }

		public SuppliersViewModelNewItem NewItem { get; set; }
	}

	public class SuppliersViewModelNewItem
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public string Website { get; set; }
	}

	public class AdminViewModelSupplier
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public string Website { get; set; }
	}
}