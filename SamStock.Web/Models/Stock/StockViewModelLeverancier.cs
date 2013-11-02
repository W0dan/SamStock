using SAMStock.Stock.GetStockRefdata;
using SAMStock.Web._Interfaces;

namespace SAMStock.Web.Models.Stock
{
    public class StockViewModelSupplier : IHasAName, IHasAnId
    {
        public StockViewModelSupplier(SupplierRefdata leverancier)
        {
            Id = leverancier.Id;
            Name = leverancier.Name;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}