﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IBOCommand<TBO> where TBO: IBO
	{
	}
}
