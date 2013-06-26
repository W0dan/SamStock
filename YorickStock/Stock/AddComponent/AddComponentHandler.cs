namespace SamStock.Stock.AddComponent
{
	public class AddComponentHandler : IAddComponentHandler
	{
		private readonly IAddComponentCommandExecutor _addComponentCommandExecutor;

		public AddComponentHandler(IAddComponentCommandExecutor addComponentCommandExecutor)
		{
			_addComponentCommandExecutor = addComponentCommandExecutor;
		}

		public void Handle(AddComponentCommand command)
		{
			_addComponentCommandExecutor.Execute(command);
		}
	}
}