using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Pedal.UpdatePedal {
    public class UpdatePedalHandler: IUpdatePedalHandler {
        private IUpdatePedalCommandExecutor _commandexecutor;

        public UpdatePedalHandler(IUpdatePedalCommandExecutor commandexecutor)
        {
            _commandexecutor = commandexecutor;
        }

        public void Handle(UpdatePedalCommand cmd)
        {
            _commandexecutor.Execute(cmd);
        }
    }
}
