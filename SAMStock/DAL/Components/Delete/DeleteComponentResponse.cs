using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentResponse: Response
	{
		public int Id { get; private set; }

		public DeleteComponentResponse(int id)
		{
			Id = id;
		}
	}
}
