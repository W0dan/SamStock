using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMStock.BO;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentResponse: Response
	{
		public Component Component { get; private set; }

		public CreateComponentResponse(Component c)
		{
			Component = c;
		}
	}
}