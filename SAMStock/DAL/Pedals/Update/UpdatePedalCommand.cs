using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedal.Update
{
	public class UpdatePedalCommand: ICommand
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
