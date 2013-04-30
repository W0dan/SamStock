namespace SamStock.Beheer.Leveranciers.GetLeveranciers {
    public class GetLeveranciersHandler : IGetLeveranciersHandler {
        private readonly IGetLeveranciersQueryExecutor _getLeveranciersQueryExecutor;

        public GetLeveranciersHandler(IGetLeveranciersQueryExecutor getLeveranciersQueryExecutor) {
            _getLeveranciersQueryExecutor = getLeveranciersQueryExecutor;
        }

        public GetLeveranciersResponse Handle(GetLeveranciersRequest request) {
            return _getLeveranciersQueryExecutor.Execute(request);
        }
    }
}