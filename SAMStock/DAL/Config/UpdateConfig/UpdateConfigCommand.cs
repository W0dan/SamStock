using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigCommand: ICommand
	{
		public decimal? VAT { get; set; }
		public decimal? DefaultPedalProfitMargin { get; set; }
	}
}
