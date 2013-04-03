using SamStock.Database;

namespace SamStock.Stock.ComponentToevoegen
{
    public class ComponentToevoegenCommandExecutor : IComponentToevoegenCommandExecutor
    {
        private readonly IContext _context;

        public ComponentToevoegenCommandExecutor(IContext context)
        {
            _context = context;
        }

        public void Execute(ComponentToevoegenCommand command)
        {
            var component = new Component
                {
                    Naam = command.Naam,
                    MinimumStock=command.MinimumStock,
                    Hoeveelheid = command.Hoeveelheid,
                    Stocknr = command.Stocknr,
                    Prijs = command.Prijs,
                    LeverancierId = command.LeverancierId,
                    Opmerkingen = command.Opmerkingen
                };

            _context.Component.AddObject(component);
        }
    }
}