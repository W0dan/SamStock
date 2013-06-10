using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Pedal.UpdatePedal {
    public interface IUpdatePedalHandler : ICommandHandler<UpdatePedalCommand> {
    }
}
