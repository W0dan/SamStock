using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedal.Delete
{
	public class DeletePedalCommand: ICommand
	{
		public int Id { get; private set; }

		public DeletePedalCommand(int id)
		{
			Id = id;
		}
	}
}
