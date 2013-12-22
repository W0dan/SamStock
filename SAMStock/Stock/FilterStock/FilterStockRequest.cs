namespace SAMStock.Stock.FilterStock
{
	public class FilterStockRequest
	{
		private readonly string _stockNr = "";
		private readonly int _supplierId = 0;
		private readonly int _componentId = 0;
		private readonly bool _manco = false;

		public FilterStockRequest()
		{
		}

		public FilterStockRequest(string stockNr = "", int supplierId = 0, int componentId = 0, bool manco = false)
		{
			_stockNr = stockNr;
			_supplierId = supplierId;
			_componentId = componentId;
			_manco = manco;
		}

		public string StockNr { get { return _stockNr; } }
		public int SupplierId { get { return _supplierId; } }
		public int ComponentId { get { return _componentId; } }
		public bool Manco { get { return _manco; } }
	}
}
