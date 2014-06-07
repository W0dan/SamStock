using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Update
{
	public class UpdatePedalHandler: BOCommandHandler<UpdatePedalCommand, Pedal>
	{
		public UpdatePedalHandler(IBOCommandExecutor<UpdatePedalCommand, Pedal> executor) : base(executor)
		{
		}
	}
}
