using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.DeleteComponent
{
	public class DeleteComponentCommand
	{
		public int Id { get; set; }
		private bool _cascade = false;
		public bool Cascade {get { return _cascade; } set { _cascade = value; }}
	}
}
