using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Create
{
	public class CreateSupplierCommand: IBOCommand<BO.Supplier>
	{
		public string Name { get; private set; }
		public string Address { get; private set; }
		public string Website { get; private set; }

		public CreateSupplierCommand(string name, string address, string website)
		{
			Name = name;
			Address = address;
			Website = website;
		}
	}
}
