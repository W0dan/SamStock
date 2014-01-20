namespace SAMStock.DTO.Supplier.DeleteSupplier
{
	public class DeleteSupplierCommand
	{
		public int Id { get; set; }
		private bool _cascade = false;
		public bool Cascade {get { return _cascade; } set { _cascade = value; }}
	}
}
