using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using SAMStock.BO;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Pedals.FilterComponents
{
	public class FilterComponentsResponse: IResponse
	{
		public Dictionary<BO.Component, int> Components { get; private set; }

		public FilterComponentsResponse(IEnumerable<ComponentsOfPedals> components)
		{
			Components = components.ToDictionary(x => new BO.Component(x.Component), y => y.Amount);
		}
	}
}
