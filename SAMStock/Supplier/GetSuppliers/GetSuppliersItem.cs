namespace SAMStock.Supplier.GetSuppliers
{
	public class GetSuppliersItem
	{
		public GetSuppliersItem()
		{
		}

		public GetSuppliersItem(string naam, string adres, string website)
		{
			Name = naam;
			Address = adres;
			Website = website;
		}

		public string Name
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

		public string Website
		{
			get;
			set;
		}
	}
}