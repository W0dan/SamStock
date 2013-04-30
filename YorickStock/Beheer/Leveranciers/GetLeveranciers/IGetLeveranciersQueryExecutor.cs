using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Beheer.Leveranciers.GetLeveranciers {
    public interface IGetLeveranciersQueryExecutor {
        GetLeveranciersResponse Execute(GetLeveranciersRequest request);
    }
}
