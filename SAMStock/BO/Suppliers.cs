using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
	public static class Suppliers
	{
		private static BOManager<Supplier> _instance;
		public static IBOManager<Supplier> Instance
		{
			get { return _instance ?? (_instance = new BOManager<Supplier>()); }
		}

		internal static BOManager<Supplier> Manager
		{
			get { return _instance ?? (_instance = new BOManager<Supplier>()); }
		}
	}
}
