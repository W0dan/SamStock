using System.Data.Objects;

namespace SamStock.Database
{
    public interface IContext
    {
        int SaveChanges();

        ObjectSet<Component> Component { get; }
        ObjectSet<Supplier> Supplier { get; }
        ObjectSet<Pedal> Pedal { get; }
        ObjectSet<PedalComponent> PedalComponent { get; }
        ObjectSet<AdminData> AdminData { get; }
    }
}