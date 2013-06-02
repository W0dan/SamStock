using SamStock.Stock.GetStockRefdata;
using SamStock.Web._Interfaces;

namespace SamStock.Web.Models
{
    public class StockViewModelLeverancier : IHasAName, IHasAnId
    {
        public StockViewModelLeverancier(LeverancierRefdata leverancier)
        {
            Id = leverancier.Id;
            Name = leverancier.Naam;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}