﻿namespace SAMStock.DAL.Supplier.UpdateSupplier
{
	public class UpdateSupplierCommand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Website { get; set; }
		public string Address { get; set; }
	}
}