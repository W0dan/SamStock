using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Create
{
	public class CreateSupplierCommand: ICreateCommand<Supplier>
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
