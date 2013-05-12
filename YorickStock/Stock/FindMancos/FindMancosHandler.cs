using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Stock.FindMancos;

namespace SamStock.Stock.FindMancos {
    public class FindMancosHandler : IFindMancosHandler {
        private readonly IFindMancosQueryExecutor _findMancosQueryExecutor;

        public FindMancosHandler(IFindMancosQueryExecutor findMancosQueryExecutor) {
            _findMancosQueryExecutor = findMancosQueryExecutor;
        }

        public FindMancosResponse Handle(FindMancosRequest request) {
            return _findMancosQueryExecutor.Execute(request);
        }
    }
}
