using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Beheer.Leveranciers.GetLeveranciers {
    public class GetLeveranciersHandler : IGetLeveranciersHandler {
        private readonly IGetLeveranciersQueryExecutor _getLeveranciersQueryExecutor;

        public GetLeveranciersHandler(IGetLeveranciersQueryExecutor GetLeveranciersQueryExecutor) {
            _getLeveranciersQueryExecutor = GetLeveranciersQueryExecutor;
        }

        public GetLeveranciersResponse Handle(GetLeveranciersRequest request) {
            return _getLeveranciersQueryExecutor.Execute(request);
        }
    }
}