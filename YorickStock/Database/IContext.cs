using System.Data.Objects;

namespace SamStock.Database
{
    public interface IContext
    {
        int SaveChanges();

        ObjectSet<Component> Component { get; }
        ObjectSet<Leverancier> Leverancier { get; }
    }
}