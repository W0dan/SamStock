using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.UpdateComponent
{
	public class UpdateComponentCommand: ICommand
	{
		public int ComponentId { get; private set; }
		public int PedalId { get; private set; }
		public int Amount { get; private set; }

		public UpdateComponentCommand(int componentid, int pedalid, int amount)
		{
			PedalId = pedalid;
			ComponentId = componentid;
			Amount = amount;
		}
	}
}
