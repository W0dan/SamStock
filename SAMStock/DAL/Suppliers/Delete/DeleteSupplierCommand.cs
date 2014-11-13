using SAMStock.BO;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Delete
{
	public class DeleteSupplierCommand: IDeleteCommand<Supplier>
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
