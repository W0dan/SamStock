namespace SAMStock.Supplier.FilterSuppliers
{
	public class FilterSuppliersHandler: IFilterSuppliersHandler
	{
		private readonly IFilterSuppliersQueryExecutor _getLeveranciersQueryExecutor;

		public FilterSuppliersHandler(IFilterSuppliersQueryExecutor getLeveranciersQueryExecutor)
		{
			_getLeveranciersQueryExecutor = getLeveranciersQueryExecutor;
		}

		public FilterSuppliersResponse Handle(FilterSuppliersRequest request)
		{
			return _getLeveranciersQueryExecutor.Execute(request);
		}
	}
}