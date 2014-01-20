namespace SAMStock.DTO.Pedal.AddPedal
{
	public class AddPedalCommand
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal? Margin { get; set; }
	}
}
