using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Pedal.DeletePedal
{
	public class DeletePedalCommand
	{
		public int Id { get; set; }
		private bool _cascade = false;
		public bool Cascade { get { return _cascade; } set { _cascade = value; } }
	}
}
