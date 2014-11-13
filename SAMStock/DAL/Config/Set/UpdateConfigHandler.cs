using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigHandler: CommandHandler<UpdateConfigRequest>
	{
		public UpdateConfigHandler(ICommandExecutor<UpdateConfigRequest> executor) : base(executor)
		{
		}
	}
}
