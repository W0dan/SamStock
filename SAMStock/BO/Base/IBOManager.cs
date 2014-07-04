using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SAMStock.BO.Base
{
	public interface IBOManager<TBO> where TBO: IBO
	{
	}
}
