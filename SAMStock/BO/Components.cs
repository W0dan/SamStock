using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
	public static class Components
	{
		private static BOManager<Component> _instance; 
		public static IBOManager<Component> Instance
		{
			get { return _instance ?? (_instance = new BOManager<Component>()); }
		}

		internal static BOManager<Component> Manager
		{
			get { return _instance ?? (_instance = new BOManager<Component>()); }
		}
	}
}