using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Pedal.UpdatePedalComponents {
    public interface IUpdatePedalComponentsCommandExecutor : ICommandExecutor {
        void Execute(UpdatePedalComponentsCommand cmd);
    }
}
