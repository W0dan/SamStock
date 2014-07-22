﻿using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.RemoveComponent
{
	public class RemoveComponentCommand: IUpdateCommand<Pedal>
	{
		public int ComponentId { get; private set; }
		public int PedalId { get; private set; }

		public RemoveComponentCommand(int componentid, int pedalid)
		{
			ComponentId = componentid;
			PedalId = pedalid;
		}
	}
}
