namespace SAMStock.DTO.Pedal.DeletePedal
{
	public class DeletePedalCommand
	{
		public int Id { get; set; }
		private bool _cascade = false;
		public bool Cascade { get { return _cascade; } set { _cascade = value; } }
	}
}
