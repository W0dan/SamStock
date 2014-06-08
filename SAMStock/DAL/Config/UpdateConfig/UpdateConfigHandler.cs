using SAMStock.DAL.Base;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigHandler: CommandHandler<UpdateConfigCommand>
	{
		public UpdateConfigHandler(ICommandExecutor<UpdateConfigCommand> executor) : base(executor)
		{
		}
	}
}
