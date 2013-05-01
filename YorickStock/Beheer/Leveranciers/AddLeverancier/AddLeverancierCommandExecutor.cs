using SamStock.Database;

namespace SamStock.Beheer.Leveranciers.AddLeverancier
{
    public class AddLeverancierCommandExecutor : IAddLeverancierCommandExecutor
    {
        private readonly IContext _context;

        public AddLeverancierCommandExecutor(IContext context)
        {
            _context = context;
        }

        public void Execute(AddLeverancierCommand command)
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