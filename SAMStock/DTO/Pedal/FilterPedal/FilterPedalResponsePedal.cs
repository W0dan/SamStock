using System.Collections.Generic;

namespace SAMStock.DTO.Pedal.FilterPedal
{
	public class FilterPedalResponsePedal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal? Margin { get; set; }
		public decimal DefaultMargin { get; set; }
		public List<int> ComponentIds { get; set; } 
	}
}
