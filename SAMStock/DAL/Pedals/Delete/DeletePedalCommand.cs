﻿using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Delete
{
	public class DeletePedalCommand: IDeleteCommand<Pedal>
	{
		public int Id { get; private set; }

		public DeletePedalCommand(int id)
		{
			Id = id;
		}
	}
}
