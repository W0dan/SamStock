using System.Collections.Generic;

namespace SAMStock.Stock.GetStockRefdata
{
    public class GetStockRefdataResponse
    {
        public IEnumerable<SupplierRefdata> Suppliers { get; set; }
    }

    public class SupplierRefdata
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}