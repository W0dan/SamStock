namespace SAMStock.DTO.Supplier.FilterSuppliers
{
	public class FilterSuppliersHandler: RequestHandler<FilterSuppliersRequest, FilterSuppliersResponse>
	{
		public FilterSuppliersHandler(IRequestExecutor<FilterSuppliersRequest, FilterSuppliersResponse> getLeveranciersRequestExecutorExecutor): base(getLeveranciersRequestExecutorExecutor)
		{
		}
	}
}