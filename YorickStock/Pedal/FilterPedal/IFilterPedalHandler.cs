using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Pedal.FilterPedal {
    public interface IFilterPedalHandler : IQueryHandler<FilterPedalRequest,FilterPedalResponse> {
    }
}