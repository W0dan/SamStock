using SamStock.Database;

namespace SamStock.Stock.ComponentToevoegen
{
    public class ComponentToevoegenCommandExecutor : IComponentToevoegenCommandExecutor
    {
        private readonly StockBeheerEntities _context;

        public ComponentToevoegenCommandExecutor(StockBeheerEntities context)
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