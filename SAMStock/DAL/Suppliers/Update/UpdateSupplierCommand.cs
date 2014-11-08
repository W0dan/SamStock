using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Update
{
	public class UpdateSupplierCommand: IUpdateCommand<Supplier>
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