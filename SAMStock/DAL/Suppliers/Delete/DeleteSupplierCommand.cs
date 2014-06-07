using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Delete
{
	public class DeleteSupplierCommand: ICommand
	{
		public int Id { get; private set; }
		public bool Cascade { get; set; }

		public DeleteSupplierCommand(int id)
		{
			Id = id;
			Cascade = false;
		}
	}
}
