using SAMStock.Utilities;

namespace SAMStock.Supplier.GetSuppliers
{
	public interface IGetSuppliersQueryExecutor : IQuery
	{
		GetSuppliersResponse Execute(GetSuppliersRequest request);
	}
}
