using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Pedal.UpdatePedalComponents {
    public class UpdatePedalComponentsCommandExecutor: IUpdatePedalComponentsCommandExecutor {
        private IContext _context;

        public UpdatePedalComponentsCommandExecutor(IContext context)
        {
            _context = context;
        }

        public void Execute(UpdatePedalComponentsCommand cmd)
        {
            if (_context.PedalComponent.Count(p => p.PedalId == cmd.Id && p.ComponentId == cmd.ComponentId) == 1)
            {
                var pedalcomp = _context.PedalComponent.Single(p => p.PedalId == cmd.Id && p.ComponentId == cmd.ComponentId);
                if (pedalcomp.Number + cmd.Quantity > 0)
                {
                    pedalcomp.Number = pedalcomp.Number + cmd.Quantity;
                } else
                {
                    _context.PedalComponent.DeleteObject(pedalcomp);
                }
            } else
            {
                _context.PedalComponent.AddObject(new PedalComponent{
                    PedalId = cmd.Id,
                    ComponentId = cmd.ComponentId,
                    Number = cmd.Quantity
                });
            }
        }
    }
}
