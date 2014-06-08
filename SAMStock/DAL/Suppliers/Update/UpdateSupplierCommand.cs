using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierCommand: IUpdateCommand<BO.Supplier>
	{
		public int Id { get; private set; }
		public string Name { get; set; }
		public string Website { get; set; }
		public string Address { get; set; }

		public UpdateSupplierCommand(int id)
		{
			Id = id;
		}
	}
}