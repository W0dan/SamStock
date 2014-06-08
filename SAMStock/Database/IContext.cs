using System.Data.Entity;

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
