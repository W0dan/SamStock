using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
	public static class Pedals
	{
		private static BOManager<Pedal> _instance;
		public static IBOManager<Pedal> Instance
		{
			get { return _instance ?? (_instance = new BOManager<Pedal>()); }
		}

		internal static BOManager<Pedal> Manager
		{
			get { return _instance ?? (_instance = new BOManager<Pedal>()); }
		}
	}
}
