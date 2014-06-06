using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO
{
	public class Supplier
	{
		public int Id { get; private set; }

		public Supplier(Database.Supplier supplier)
		{
			Id = supplier.Id;
		}
	}
}
