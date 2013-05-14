namespace SamStock.Stock.FilterStock {
    public class FilterStockRequest {
        private readonly string _stockNr;
        private readonly int _leverancierID;
        private readonly bool _manco;

        public FilterStockRequest() {
            _stockNr = "";
            _leverancierID = 0;
            _manco = false;
        }

        public FilterStockRequest(string stockNr, int leverancierID, bool manco) {
            _stockNr = stockNr;
            _leverancierID = leverancierID;
            _manco = manco;
        }

        public FilterStockRequest(string stockNr, int leverancierID) {
            _stockNr = stockNr;
            _leverancierID = leverancierID;
            _manco = false;
        }

        public string StockNr { get { return _stockNr; } }
        public int LeverancierID { get { return _leverancierID; } }
        public bool Manco { get { return _manco; } }
    }
}
