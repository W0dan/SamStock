using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMStock.Business.Events;
using SAMStock.Business.Foundation;
using SAMStock.Business.Objects;

namespace SAMStock.Business.Managers
{
	public class Configs: Manager<Config>
	{
		public override void RegisterCreate(Action<object, Created<Config>> listener)
		{
			throw new InvalidOperationException("Cannot subscribe to Creation event of configs.");
		}

		public override void RegisterDelete(Action<object, Deleted<Config>> listener)
		{
			throw new InvalidOperationException("Cannot subscribe to Deletion event of configs.");
		}
	}
}
