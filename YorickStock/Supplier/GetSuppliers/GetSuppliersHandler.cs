namespace SamStock.Supplier.GetSuppliers {
    public class GetSuppliersHandler : IGetSuppliersHandler {
        private readonly IGetSuppliersQueryExecutor _getLeveranciersQueryExecutor;

        public GetSuppliersHandler(IGetSuppliersQueryExecutor getLeveranciersQueryExecutor) {
            _getLeveranciersQueryExecutor = getLeveranciersQueryExecutor;
        }

        public GetSuppliersResponse Handle(GetSuppliersRequest request) {
            return _getLeveranciersQueryExecutor.Execute(request);
        }
    }
}