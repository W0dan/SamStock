using System.Collections;
using System.Collections.Generic;
using SamStock.Supplier.GetSuppliers;
using System.Linq;

namespace SamStock.Web.Models.Supplier
{
	public class SuppliersViewModel
	{
		public SuppliersViewModel(GetSuppliersResponse getLeveranciersResponse)
		{
			List = getLeveranciersResponse.List
				.Select(x => new BeheerViewModelLeverancier { Address = x.Address, Name = x.Name, Website = x.Website }).ToList();
		}

		public List<BeheerViewModelLeverancier> List { get; set; }

		public LeveranciersViewModelNewItem NewItem { get; set; }
	}

	public class LeveranciersViewModelNewItem
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public string Website { get; set; }
	}

	public class BeheerViewModelLeverancier
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public string Website { get; set; }
	}
}