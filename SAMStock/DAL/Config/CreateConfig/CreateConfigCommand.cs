using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Config.CreateConfig
{
	public class CreateConfigCommand: ICommand
	{
		// ReSharper disable once InconsistentNaming
		public decimal VAT { get; private set; }
		public decimal DefaultPedalProfitMargin { get; private set; }

		public CreateConfigCommand(decimal vat, decimal margin)
		{
			VAT = vat;
			DefaultPedalProfitMargin = margin;
		}
	}
}
