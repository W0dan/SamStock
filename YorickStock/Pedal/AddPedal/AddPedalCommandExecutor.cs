using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Pedal.AddPedal {
    public class AddPedalCommandExecutor : IAddPedalCommandExecutor {
        private IContext _context;

        public AddPedalCommandExecutor(IContext context)
        {
            _context = context;
        }

        public void Execute(AddPedalCommand cmd)
        {
            _context.Pedal.AddObject(new Database.Pedal {
                Name = cmd.Name,
                Price = cmd.Price,
                Margin = cmd.Margin
            });
        }
    }
}
