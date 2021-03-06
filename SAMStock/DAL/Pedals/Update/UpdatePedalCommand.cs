﻿using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Update
{
	public class UpdatePedalCommand: IUpdateCommand<Pedal>
	{
		public int Id { get; private set; }
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public decimal? ProfitMargin { get; set; }

		public UpdatePedalCommand(int id)
		{
			Id = id;
		}
	}
}
