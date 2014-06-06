using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace SAMStock.Database
{
	public interface IContext
	{
		DbSet<Component> Components { get; }
		DbSet<Pedal> Pedals { get; }
		DbSet<ComponentsOfPedals> ComponentsOfPedals { get; }
		DbSet<Config> Config { get; }
		DbSet<Supplier> Suppliers { get; }
		int SaveChanges();
	}
}
