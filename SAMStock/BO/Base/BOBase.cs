using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Base
{
	public abstract class BOBase: EventArgs, IBO
	{
		public int Id { get; protected set; }
	}
}
