namespace SAMStock.DAL.Pedal.AddComponent
{
	public class AddComponentCommand
	{
		public int PedalId { get; set; }
		public int ComponentId { get; set; }
		public int Quantity { get; set; }
	}
}
