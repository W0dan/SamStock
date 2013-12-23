using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor.Diagnostics.Extensions;

namespace SAMStock.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommand
	{
		public int Id { get; set; }
		private bool _cascade = false;
		public bool Cascade {get { return _cascade; } set { _cascade = value; }}
	}
}
