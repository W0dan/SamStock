using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Stock.FindMancos {
    public interface IFindMancosQueryExecutor:IQuery {
        FindMancosResponse Execute(FindMancosRequest request);
    }
}
