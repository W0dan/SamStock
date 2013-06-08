using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Pedal.FilterPedal {
    public interface IFilterPedalQueryExecutor : IQuery {
        FilterPedalResponse Execute(FilterPedalRequest request);
    }
}
