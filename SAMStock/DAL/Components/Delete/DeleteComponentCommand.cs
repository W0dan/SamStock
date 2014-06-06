using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentCommand: ICommand
	{
		public int Id { get; private set; }
		public bool Cascade { get; set; }

		public DeleteComponentCommand(int id)
		{
			Id = id;
		}
	}
}
