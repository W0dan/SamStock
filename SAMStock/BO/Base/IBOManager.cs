using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Base
{
	public interface IBOManager<T> where T: BOBase
	{
		event EventHandler<T> Created;
		event EventHandler<T> Deleted;
		event EventHandler<T> Updated;
	}
}
