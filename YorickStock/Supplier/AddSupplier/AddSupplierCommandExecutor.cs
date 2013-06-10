using SamStock.Database;

namespace SamStock.Supplier.AddSupplier
{
    public class AddSupplierCommandExecutor : IAddSupplierCommandExecutor
    {
        private readonly IContext _context;

        public AddSupplierCommandExecutor(IContext context)
        {
            _context = context;
        }

        public void Execute(AddSupplierCommand command)
        {
            var leverancier = new Leverancier
                {
                    Naam = command.Name,
                    Adres = command.Address,
                    Site = command.Website
                };

            _context.Leverancier.AddObject(leverancier);
        }
    }
}