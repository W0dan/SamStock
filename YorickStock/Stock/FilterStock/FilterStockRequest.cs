namespace SamStock.Stock.FilterStock {
    public class FilterStockRequest {
        private readonly string _stockNr;
        private readonly int _leverancierID;

        public FilterStockRequest(string stockNr, int leverancierID) {
            _stockNr = stockNr;
            _leverancierID = leverancierID;
        }

        public string StockNr { get { return _stockNr; } }
        public int LeverancierID { get { return _leverancierID; } }
    }
}
