using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO
{
	public class Pedal
	{
		public int Id { get; private set; }

		public Pedal(Database.Pedal pedal)
		{
			Id = pedal.Id;
		}
	}
}
