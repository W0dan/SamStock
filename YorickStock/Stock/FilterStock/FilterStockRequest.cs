namespace SamStock.Stock.FilterStock
{
	public class FilterStockRequest
	{
		private readonly string _stockNr;
		private readonly int _supplierId;
		private readonly bool _manco;

		public FilterStockRequest()
		{
			_stockNr = "";
			_supplierId = 0;
			_manco = false;
		}

		public FilterStockRequest(string stockNr, int leverancierID, bool manco)
		{
			_stockNr = stockNr;
			_supplierId = leverancierID;
			_manco = manco;
		}

		public string StockNr { get { return _stockNr; } }
		public int SupplierId { get { return _supplierId; } }
		public bool Manco { get { return _manco; } }
	}
}
