using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Pedal.AddPedal {
    public interface IAddPedalCommandExecutor : ICommandExecutor {
        void Execute(AddPedalCommand cmd);
    }
}
