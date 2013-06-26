using SamStock.Utilities;

namespace SamStock.Supplier.GetSuppliers
{
	public interface IGetSuppliersQueryExecutor : IQuery
	{
		GetSuppliersResponse Execute(GetSuppliersRequest request);
	}
}
