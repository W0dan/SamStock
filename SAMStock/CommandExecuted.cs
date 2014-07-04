using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.DAL.Config.GetConfig;

namespace SAMStock
{
	public class CommandExecuted: EventArgs
	{
		public ICommand Command { get; private set; }

		public Type CommandType { get; private set; }

		internal CommandExecuted(ICommand cmd)
		{
			Command = cmd;
			CommandType = cmd.GetType();
		}
	}
}
