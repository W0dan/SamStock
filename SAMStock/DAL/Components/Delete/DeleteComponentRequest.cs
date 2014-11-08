using System;
using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentRequest: Request<DeleteComponentResponse>
	{
		public int Id { get; private set; }
		public bool Cascade { get; set; }

		public DeleteComponentRequest(Object sender, int id): base(sender)
		{
			Id = id;
			Cascade = false;
		}
	}
}
