﻿namespace SAMStock.DTO.Component.AddComponent
{
	public class AddComponentCommand
	{
		public string Name { get; set; }
		public int MinimumStock { get; set; }
		public int Quantity { get; set; }
		public string Stocknr { get; set; }
		public decimal Price { get; set; }
		public int SupplierId { get; set; }
		public string Remarks { get; set; }
		public string ItemCode { get; set; }
	}
}