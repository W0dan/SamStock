using SamStock.Utilities;

namespace SamStock.Stock.ComponentToevoegen
{
    public class ComponentToevoegenCommand:ICommandExecutor
    {
        private readonly string _naam;
        private readonly int _minimumStock;
        private readonly int _hoeveelheid;
        private readonly string _stocknr;
        private readonly decimal _prijs;
        private readonly int _leverancierId;
        private readonly string _opmerkingen;

        public ComponentToevoegenCommand(string naam, int minimumStock, int hoeveelheid, string stocknr, decimal prijs, int leverancierId, string opmerkingen)
        {
            _naam = naam;
            _minimumStock = minimumStock;
            _hoeveelheid = hoeveelheid;
            _stocknr = stocknr;
            _prijs = prijs;
            _leverancierId = leverancierId;
            _opmerkingen = opmerkingen;
        }

        public string Naam
        {
            get { return _naam; }
        }

        public int MinimumStock
        {
            get { return _minimumStock; }
        }

        public int Hoeveelheid
        {
            get { return _hoeveelheid; }
        }

        public string Stocknr
        {
            get { return _stocknr; }
        }

        public decimal Prijs
        {
            get { return _prijs; }
        }

        public int LeverancierId
        {
            get { return _leverancierId; }
        }

        public string Opmerkingen
        {
            get { return _opmerkingen; }
        }
    }
}