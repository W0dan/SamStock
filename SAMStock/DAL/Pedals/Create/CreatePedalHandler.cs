﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Create
{
	public class CreatePedalHandler: BOCommandHandler<CreatePedalCommand, Pedal>
	{
		public CreatePedalHandler(IBOCommandExecutor<CreatePedalCommand, Pedal> executor) : base(executor)
		{
		}
	}
}