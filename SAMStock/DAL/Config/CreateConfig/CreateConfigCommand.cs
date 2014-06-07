﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Config.CreateConfig
{
	public class CreateConfigCommand
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