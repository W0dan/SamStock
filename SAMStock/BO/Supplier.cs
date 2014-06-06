using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO
{
	public class Supplier
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public Uri Website { get; private set; }
		public string Address { get; private set; }

		public Supplier(Database.Supplier supplier)
		{
			Id = supplier.Id;
			Name = supplier.Name;
			try
			{
				Website = new Uri(supplier.Website);
			}
			catch (UriFormatException)
			{
				Website = new Uri(String.Format("https://www.google.co.uk/#q={0}", supplier.Name));
			}
			Address = supplier.Address;
		}
	}
}
