using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using SAMStock.DAL.Foundation;
using Component = SAMStock.Business.Objects.Component;

namespace SAMStock.DAL.Components.Update
{
	public class UpdateComponentResponse: Response
	{
		public Component Component { get; private set; }

		public UpdateComponentResponse(Component component)
		{
			Component = component;
		}
	}
}
