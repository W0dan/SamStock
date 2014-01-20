namespace SAMStock.DTO.Component.DeleteComponent
{
	public class DeleteComponentCommand
	{
		public int Id { get; set; }
		public bool Cascade { get; set; }

		public DeleteComponentCommand()
		{
			Cascade = false;
		}
	}
}
